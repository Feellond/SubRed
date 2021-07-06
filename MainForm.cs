using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using Microsoft.Office.Interop.Word;

namespace SubRed
{
    public partial class MainForm : Form
    {
        public struct tableSort
        {
            public int num;
            public DataGridViewRow row;
            public TimeSpan begin;
            public TimeSpan end;
        };

        private int WM_KEYDOWN = 0x100;
        private int rowIndex;

        enum MediaStatus { None, Stopped, Paused, Running };

        private MediaStatus m_CurrentStatus = MediaStatus.None;

        private string buffer;  // хранение строки при вводе
        private int position;   // хранение позиции при вводе
        private bool isStarted; // запущен ли timer2

        private bool subChanged;
        private bool trackBarIsMoving;
        private string videoFileName;
        private string subFileName;
        private string FileNamePath;
        private bool isSelectedCrossed;
        private DataGridViewRow dgvCopyRow;
        private PluginBase pluginBase;
        private EditSubtitleClass editSubClass;
        private List<tableSort> tableSortList;
        private Sub_formats.SubFormats subFormats;
        private Color tableDefaultColor;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0302 || m.Msg == 0x0301 || m.Msg == 0x0300)   //0x0302 - WM_PASTE    0x0301 - WM_COPY   0x0300 - WM_CUT
            {
                // ignore input if it was from a keyboard shortcut
                // or a Menu command
                MessageBox.Show(this, "В буфере обмена нет текста", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // handle the windows message normally
                base.WndProc(ref m);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.ActiveControl.Name == "editedSubTextBox" || this.ActiveControl.Name == "dataGridView1")
            {
                if (keyData == (Keys.Control | Keys.V))
                {
                    if (this.ActiveControl.Name == "editedSubTextBox")
                    {
                        editSubClass.EditListAdd(editedSubTextBox.Name, "Вставка", editedSubTextBox.SelectionStart, Clipboard.GetText());
                        this.editedSubTextBox.TextChanged -= this.editedSubTextBox_TextChanged;
                        editedSubTextBox.Text = editedSubTextBox.Text.Insert(editedSubTextBox.SelectionStart, Clipboard.GetText());
                        this.editedSubTextBox.TextChanged += this.editedSubTextBox_TextChanged;
                        return true;
                    }
                    else if (Clipboard.GetText().Contains("Dialogue:"))
                    {
                        InsertAfterFunction(subDataGridView);
                        return true;
                    }
                }
                else if (keyData == (Keys.Control | Keys.C))
                {
                    if (this.ActiveControl.Name == "editedSubTextBox")
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }
                    else
                    {
                        CopyRowFunction(subDataGridView);
                        return true;
                    }
                }
                else if (keyData == (Keys.Control | Keys.X))
                {
                    if (this.ActiveControl.Name == "editedSubTextBox")
                    {
                        editSubClass.EditListAdd(editedSubTextBox.Name, "Выразание", editedSubTextBox.SelectionStart, editedSubTextBox.SelectedText);
                        this.editedSubTextBox.TextChanged -= this.editedSubTextBox_TextChanged;
                        editedSubTextBox.Text = editedSubTextBox.Text.Replace(editedSubTextBox.SelectedText, "");
                        this.editedSubTextBox.TextChanged += this.editedSubTextBox_TextChanged;
                        return true;
                    }
                    else
                    {
                        CutRowFunction(subDataGridView);
                        return true;
                    }
                }
                else if (keyData == (Keys.Control | Keys.Z))
                {
                    if (this.ActiveControl.Name == "editedSubTextBox")
                    {
                        editSubClass.Undo(pluginBase.subtitles, editedSubTextBox, subDataGridView);
                        return true;
                    }
                }
                else if (keyData == (Keys.Control | Keys.Y))
                {
                    if (this.ActiveControl.Name == "editedSubTextBox")
                    {
                        editSubClass.Return(pluginBase.subtitles, editedSubTextBox, subDataGridView);
                        return true;
                    }
                }
                else if (keyData == Keys.Delete)
                {
                    if (this.ActiveControl.Name == "editedSubTextBox")
                    {

                        return base.ProcessCmdKey(ref msg, keyData);
                    }
                    else
                    {
                        DeleteRowFunction(subDataGridView);
                        return true;
                    }
                }/*
                else if (keyData == Keys.Back)
                {
                    if (this.ActiveControl.Name == "editedSubTextBox")
                    {

                        return true;
                    }
                }*/
                else if (keyData == (Keys.Control | Keys.S))
                {
                    subFormats.SelectFormat(subFileName, pluginBase.subtitles.getSubtitlesString(), false);
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public string RowToString(DataGridViewRow row)
        {
            string str = "Dialogue: ";
            for (int i = 1; i < row.Cells.Count; i++)
            {
                str += row.Cells[i].Value.ToString();
                if (i + 1 < row.Cells.Count)
                    str += ",";
            }

            return str;
        }

        public DataGridViewRow StringToRow(string str)
        {
            DataGridViewRow row = subDataGridView.Rows[0];
            for (int i = 0; i < row.Cells.Count; i++)
                row.Cells[i].Value = "";
            try
            {
                string[] strSplit = str.Split(':')[1].Split(',');
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    row.Cells[i].Value = strSplit[i];
                }

            }
            catch { }
            return row;
        }

        [ComImport, System.Security.SuppressUnmanagedCodeSecurity, Guid("388EEF20-40CC-4752-A0FF-66AA5C4AF8FA"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ISettingsInterface
        {
            [PreserveSig]
            int get_FileName(
                [MarshalAs(UnmanagedType.LPStr)] String fn
                );

            [PreserveSig]
            int put_FileName(
                [MarshalAs(UnmanagedType.LPStr)] String fn
                );
        }

        private void vlcControl_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            // Default installation path of VideoLAN.LibVLC.Windows
            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }

        public MainForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);


            UpdateStatusBar();
            UpdateToolBar();

            trackBarIsMoving = false;

            //this.vlcControl1.VlcLibDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));


            foreach (DataGridViewColumn dgvColumn in subDataGridView.Columns)
                dgvColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;   // выравнивание по центру

            subFileName = "";

            var currentDirectory = Directory.GetCurrentDirectory();
            var libDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
            var options = new string[]
            {
                // VLC options can be given here. Please refer to the VLC command line documentation.
                "-vv"
            };
            var mediaPlayer = new Vlc.DotNet.Core.VlcMediaPlayer(libDirectory);
            var mediaOptions = new string[]
            {
                ":sout=#file{dst="+Path.Combine(Environment.CurrentDirectory, "output.mov")+"}",
                ":sout-keep"
            };
        }

        private void openVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Media Files|*.mpg;*.avi;*.wma;*.mov;*.wav;*.mp2;*.mp3|All Files|*.*"
            };

            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                CleanUp();

                FileNamePath = openFileDialog.FileName;
                //this.vlcControl1.SetMedia(@"file:///" + openFileDialog.FileName);
                //vlcControl1.Play();

                try
                {
                    this.panelVideo.Controls.Remove(this.panelVideo.Controls.Find("vlcControl1", false)[0]);
                }
                catch { }

                vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
                vlcControl1.BeginInit();
                this.vlcControlPanel.Controls.Add(vlcControl1);
                this.vlcControl1.BringToFront();
                this.vlcControl1.BackColor = System.Drawing.Color.Black;
                this.vlcControl1.Location = new System.Drawing.Point(37, 4);
                this.vlcControl1.Name = "vlcControl1";
                this.vlcControl1.Size = new System.Drawing.Size(426, 240);
                this.vlcControl1.Dock = DockStyle.Fill;
                this.vlcControl1.Spu = -1;
                this.vlcControl1.TabIndex = 6;
                this.vlcControl1.Text = "vlcControl1";
                this.vlcControl1.VlcLibDirectory = null;
                vlcControl1.VlcMediaplayerOptions = new string[] { "--no-sub-autodetect-file", "--sub-autodetect-fuzzy=1" };
                this.vlcControl1.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl_VlcLibDirectoryNeeded);
                vlcControl1.EndInit();


                videoFileName = openFileDialog.FileName;
                this.vlcControl1.SetMedia(@"file:///" + videoFileName);
                vlcControl1.Play();

                var media = vlcControl1.VlcMediaPlayer.GetMedia();
                media.Parse();
                int s = (int)media.Duration.TotalSeconds;
                trackBar1.Minimum = 0;
                trackBar1.Maximum = (int)media.Duration.TotalSeconds;
                trackBar1.Value = (int)vlcControl1.Time / 1000;
                trackBar1.TickFrequency = 60;

                m_CurrentStatus = MediaStatus.Running;
                UpdateStatusBar();
                UpdateToolBar();

                timer1.Start();
            }

            //Thread.Sleep(1000);
            //VideoPictureBoxCreate();
        }

        private void CleanUp()
        {
            if (vlcControl1.VlcMediaPlayer.GetMedia() != null)
                vlcControl1.Stop();

            m_CurrentStatus = MediaStatus.None;
            UpdateStatusBar();
            UpdateToolBar();
        }

        private void UpdateStatusBar()
        {
            switch (m_CurrentStatus)
            {
                case MediaStatus.None: statusBarPanel1.Text = "Stopped"; break;
                case MediaStatus.Paused: statusBarPanel1.Text = "Paused "; break;
                case MediaStatus.Running: statusBarPanel1.Text = "Running"; break;
                case MediaStatus.Stopped: statusBarPanel1.Text = "Stopped"; break;
            }

            if (vlcControl1.VlcMediaPlayer.GetMedia() != null)
            {

                //int s = (int)vlcControl1.VlcMediaPlayer.GetMedia().Duration.TotalSeconds;
                var media = vlcControl1.VlcMediaPlayer.GetMedia();
                media.Parse();
                int s = (int)media.Duration.TotalSeconds;
                int h = s / 3600;
                int m = (s - (h * 3600)) / 60;
                s = s - (h * 3600 + m * 60);

                statusBarPanel3.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);
                var position = vlcControl1.Time;

                s = (int)vlcControl1.Time / 1000;
                h = s / 3600;
                m = (s - (h * 3600)) / 60;
                s = s - (h * 3600 + m * 60);

                statusBarPanel2.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);

                if (!trackBarIsMoving)
                    trackBar1.Value = s;
            }
            else
            {
                statusBarPanel2.Text = "00:00:00";
                statusBarPanel3.Text = "00:00:00";

                trackBar1.Value = 0;
            }
        }

        private void UpdateToolBar()
        {
            switch (m_CurrentStatus)
            {
                case MediaStatus.None:
                    toolBarButton1.Enabled = false;
                    toolBarButton2.Enabled = false;
                    toolBarButton3.Enabled = false;
                    break;

                case MediaStatus.Paused:
                    toolBarButton1.Enabled = true;
                    toolBarButton2.Enabled = false;
                    toolBarButton3.Enabled = true;
                    break;

                case MediaStatus.Running:
                    toolBarButton1.Enabled = false;
                    toolBarButton2.Enabled = true;
                    toolBarButton3.Enabled = true;
                    break;

                case MediaStatus.Stopped:
                    toolBarButton1.Enabled = true;
                    toolBarButton2.Enabled = false;
                    toolBarButton3.Enabled = false;
                    break;
            }
        }

        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            switch (toolBar1.Buttons.IndexOf(e.Button))
            {
                case 0:
                    vlcControl1.Play();
                    // m_objMediaControl.Run();
                    m_CurrentStatus = MediaStatus.Running;
                    timer1.Start();
                    break;

                case 1:
                    vlcControl1.Pause();
                    //m_objMediaControl.Pause();
                    m_CurrentStatus = MediaStatus.Paused;
                    timer1.Stop();
                    break;

                case 2:
                    vlcControl1.Stop();
                    vlcControl1.Position = 0;
                    //m_objMediaControl.Stop();
                    //m_objMediaPosition.CurrentPosition = 0;
                    m_CurrentStatus = MediaStatus.Stopped;
                    timer1.Stop();
                    break;
            }

            UpdateStatusBar();
            UpdateToolBar();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (m_CurrentStatus == MediaStatus.Running)
            {
                UpdateStatusBar();
            }
        }

        private void NewLoad()
        {
            pluginBase = new PluginBase();
            pluginBase.subtitles.stylesFormat = "Name,Fontname,Fontsize,PrimaryColour,SecondaryColour," +
                    "OutlineColour,BackColour,Bold,Italic,Underline,StrikeOut,ScaleX," +
                    "ScaleY,Spacing,Angle,BorderStyle,Outline,Shadow,Alignment," +
                    "MarginL,MarginR,MarginV,AlphaLevel,Encoding";

            string style = "Default,Arial,26,FFFFFF,FFFFFF,000000,000000,0,0,0,0,100,100,0,0,1,1,2,2,10,10,10,0,0";
            pluginBase.subtitles.style.Add(style);
            string textFormat = "Layer,Start,End,Style,Name,MarginL,MarginR,MarginV,Effect,Text";
            pluginBase.subtitles.TextFormat = textFormat;
            string text = "1,0,00:00:00.500,00:00:05.000,,,,,,,Default Text";
            pluginBase.subtitles.text.Add(text);

            pluginBase.grid = subDataGridView;

            rowIndex = -1;
            subDataGridView.Rows.Clear();
            subDataGridView.Rows.Add();

            for (int i = 0; i < subDataGridView.Rows[0].Cells.Count; i++)
                subDataGridView.Rows[0].Cells[i].Value = "";

            subDataGridView.Rows[0].Cells[0].Value = 1;
            subDataGridView.Rows[0].Cells[1].Value = 0;
            subDataGridView.Rows[0].Cells[2].Value = "00:00:00.000";
            subDataGridView.Rows[0].Cells[3].Value = "00:00:05.000";
            subDataGridView.Rows[0].Cells[4].Value = "";
            subDataGridView.Rows[0].Cells[5].Value = "";
            subDataGridView.Rows[0].Cells[6].Value = "";
            subDataGridView.Rows[0].Cells[7].Value = "";
            subDataGridView.Rows[0].Cells[8].Value = "";
            subDataGridView.Rows[0].Cells[9].Value = "";
            subDataGridView.Rows[0].Cells[10].Value = "Default Text";

            subDataGridView.Rows[0].Selected = true;
            subDataGridView.CurrentCell = subDataGridView.Rows[0].Cells[0];
            GridSelect();

            loadStylesInComboBox();

            isSelectedCrossed = false;

            rowIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tableSortList = new List<tableSort>();
            subFormats = new Sub_formats.SubFormats();
            editSubClass = new EditSubtitleClass();
            isStarted = false;

            originalSubTextBox.Hide();
            editedSubTextBox.Dock = DockStyle.Fill;
            // Create the ToolTip and associate with the Form container.
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.originalSubTextBox, "Поле субтитров до изменения (оригинал)");
            toolTip1.SetToolTip(this.editedSubTextBox, "Поле субтитров");

            NewLoad();

            //DirectoryInfo d = new DirectoryInfo(System.Reflection.Assembly.GetEntryAssembly().Location);
            try
            {
                DirectoryInfo d = new DirectoryInfo(System.Windows.Forms.Application.StartupPath + "\\plugins");
                var files = d.GetFiles("*.dll");
                pluginBase.menuItem = findAndChangeToolStripMenuItem;
                foreach (var file in files)
                {
                    pluginBase.LoadPluginFunction(file.FullName, file.Name, true);
                }
            }
            catch { }

            tableDefaultColor = subDataGridView.Rows[0].DefaultCellStyle.BackColor;
        }

        public void loadStylesInComboBox()
        {
            styleComboBox.Items.Clear();

            int indexInStyleFormat = Array.IndexOf(pluginBase.subtitles.stylesFormat.Split(','), "Name");
            foreach (string style in pluginBase.subtitles.style)
            {
                string n = style.Split(',')[indexInStyleFormat];
                styleComboBox.Items.Add(n);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GridSelect();
            subDataGridView.Rows[subDataGridView.CurrentRow.Index].Selected = true;
        }

        private void GridSelect()
        {
            try
            {
                levelDomainUpDown.Text = Convert.ToString(subDataGridView.CurrentRow.Cells[1].Value);
                beginTextBox.Text = subDataGridView.CurrentRow.Cells[2].Value.ToString();
                endTextBox.Text = subDataGridView.CurrentRow.Cells[3].Value.ToString();

                beginTextBox.Text.Replace(',', '.');
                endTextBox.Text.Replace(',', '.');
            }
            catch
            {

            }
            for (int i = 0; i < styleComboBox.Items.Count; i++)
            {
                if (styleComboBox.Items[i].ToString() == Convert.ToString(subDataGridView.CurrentRow.Cells[4].Value))
                    styleComboBox.SelectedIndex = i;
            }

            for (int i = 0; i < actorComboBox.Items.Count; i++)
            {
                if (actorComboBox.Items[i].ToString() == Convert.ToString(subDataGridView.CurrentRow.Cells[5].Value))
                    actorComboBox.SelectedIndex = i;
            }

            for (int i = 0; i < effectComboBox.Items.Count; i++)
            {
                if (effectComboBox.Items[i].ToString() == Convert.ToString(subDataGridView.CurrentRow.Cells[6].Value))
                    effectComboBox.SelectedIndex = i;
            }

            leftMaskedTextBox.Text = Convert.ToString(subDataGridView.CurrentRow.Cells[7].Value);
            rightMaskedTextBox.Text = Convert.ToString(subDataGridView.CurrentRow.Cells[8].Value);
            vertMaskedTextBox.Text = Convert.ToString(subDataGridView.CurrentRow.Cells[9].Value);


            editedSubTextBox.Text = Convert.ToString(subDataGridView.CurrentRow.Cells[10].Value);

            DurationChange();
        }

        private void DurationChange() // изменение textBox длительности
        {
            try
            {
                TimeSpan convertedTime;
                convertedTime = TimeSpan.Parse(endTextBox.Text) - TimeSpan.Parse(beginTextBox.Text);
                durationTextBox.Text = convertedTime.ToString() + '.' + convertedTime.TotalMilliseconds.ToString().Substring(convertedTime.TotalMilliseconds.ToString().Length - 3);
            }
            catch { }
        }

        private void DublicateRowFunction(DataGridView grid)
        {
            rowIndex = -1;
            editSubClass.EditListAdd(subDataGridView.Name, "Вставка", grid.CurrentRow.Index, RowToString(grid.CurrentRow));
            grid.Rows.Insert(grid.CurrentRow.Index, grid.Rows[grid.CurrentRow.Index]);
            tableReNum(grid);
            rowIndex = subDataGridView.CurrentRow.Index;
        }

        private void dublicateRow(object sender, EventArgs e)
        {
            DublicateRowFunction(subDataGridView);
        }

        private void DeleteRowFunction(DataGridView grid)
        {
            rowIndex = -1;
            var result = MessageBox.Show("Вы уверены, что хотите удалить строку под номером " + grid.CurrentRow.Index.ToString() + "?",
                "Подтвердите удаление",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                editSubClass.EditListAdd(grid.Name, "Удаление", grid.CurrentRow.Index, RowToString(grid.CurrentRow));
                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                tableReNum(grid);
            }
            rowIndex = subDataGridView.CurrentRow.Index;
        }

        private void deleteRow(object sender, EventArgs e)
        {
            DeleteRowFunction(subDataGridView);
        }

        private void CopyRowFunction(DataGridView grid)
        {
            rowIndex = -1;
            dgvCopyRow = grid.Rows[grid.CurrentRow.Index];
            Clipboard.SetText(RowToString(grid.CurrentRow));
            rowIndex = subDataGridView.CurrentRow.Index;
        }

        private void copyRow(object sender, EventArgs e)
        {
            CopyRowFunction(subDataGridView);
        }

        private void CutRowFunction(DataGridView grid)
        {
            rowIndex = -1;
            dgvCopyRow = grid.Rows[grid.CurrentRow.Index];
            grid.Rows.RemoveAt(grid.CurrentRow.Index);

            string str = RowToString(dgvCopyRow);
            editSubClass.EditListAdd(grid.Name, "Вырезание", grid.CurrentRow.Index, str);
            Clipboard.SetText(str);
            rowIndex = subDataGridView.CurrentRow.Index;
        }

        private void cutRow(object sender, EventArgs e)
        {
            CutRowFunction(subDataGridView);
        }

        private int InsertAfterFunction(DataGridView grid)
        {
            rowIndex = -1;
            if (dgvCopyRow != null)
            {
                grid.Rows.Insert(grid.CurrentRow.Index, dgvCopyRow);
            }

            tableReNum(grid);
            editSubClass.EditListAdd(grid.Name, "Вставка", grid.CurrentRow.Index, Clipboard.GetText());
            rowIndex = subDataGridView.CurrentRow.Index;
            return grid.CurrentRow.Index;
        }

        private void insertAfterRow(object sender, EventArgs e)
        {
            InsertAfterFunction(subDataGridView);
        }

        private int InsertNewBeforeFunction(DataGridView grid)
        {
            rowIndex = -1;
            int num = grid.CurrentRow.Index;
            grid.Rows.Insert(grid.CurrentRow.Index,
                Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells[0].Value) - 1,
                "",
                grid.Rows[grid.CurrentRow.Index].Cells[2].Value,
                grid.Rows[grid.CurrentRow.Index].Cells[3].Value,
                grid.Rows[grid.CurrentRow.Index].Cells[4].Value,
                "",
                "",
                "",
                "",
                "",
                "",
                "");

            editSubClass.EditListAdd(grid.Name, "Вставка", grid.CurrentRow.Index - 1, RowToString(grid.CurrentRow));
            tableReNum(grid);
            rowIndex = subDataGridView.CurrentRow.Index;
            return num;
        }

        private void insertNewBeforeRow(object sender, EventArgs e)
        {
            InsertNewBeforeFunction(subDataGridView);
        }

        private int InsertNewAfterFunction(DataGridView grid)
        {
            rowIndex = -1;
            DataGridViewRow dgvr = (DataGridViewRow)grid.Rows[0].Clone();

            for (int i = 0; i < dgvr.Cells.Count; i++)
                dgvr.Cells[i].Value = "";

            dgvr.Cells[2].Value = grid.Rows[grid.CurrentRow.Index].Cells[2].Value;
            dgvr.Cells[3].Value = grid.Rows[grid.CurrentRow.Index].Cells[3].Value;
            dgvr.Cells[4].Value = grid.Rows[grid.CurrentRow.Index].Cells[4].Value;

            if (grid.CurrentRow.Index + 1 >= grid.Rows.Count)
                grid.Rows.Add(dgvr);
            else
                grid.Rows.Insert(grid.CurrentRow.Index + 1, dgvr);

            editSubClass.EditListAdd(grid.Name, "Вставка", grid.CurrentRow.Index + 1, RowToString(grid.Rows[grid.CurrentRow.Index + 1]));
            tableReNum(grid);
            rowIndex = subDataGridView.CurrentRow.Index;
            return grid.CurrentRow.Index;
        }

        private void insertNewAfterRow(object sender, EventArgs e)
        {
            InsertNewAfterFunction(subDataGridView);
        }

        public void tableReNum(DataGridView grid)
        {
            for (int i = 0; i < grid.RowCount; i++)
            {
                grid.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Вырезать", new EventHandler(this.cutRow)));
                m.MenuItems.Add(new MenuItem("Скопировать", new EventHandler(this.copyRow)));
                m.MenuItems.Add(new MenuItem("Вставить строку", new EventHandler(this.insertAfterRow)));
                m.MenuItems.Add("-");
                m.MenuItems.Add(new MenuItem("Вставить перед", new EventHandler(this.insertNewBeforeRow)));
                m.MenuItems.Add(new MenuItem("Вставить после", new EventHandler(this.insertNewAfterRow)));
                m.MenuItems.Add(new MenuItem("Дублировать", new EventHandler(this.dublicateRow)));
                m.MenuItems.Add("-");
                m.MenuItems.Add(new MenuItem("Удалить", new EventHandler(this.deleteRow)));

                m.Show(subDataGridView, new System.Drawing.Point(e.X, e.Y));

            }
        }

        private void trackBar1_MouseCaptureChanged(object sender, EventArgs e)
        {
            try
            {
                //m_objMediaControl.Pause();
                if (m_CurrentStatus == MediaStatus.Running)
                    vlcControl1.Pause();

                m_CurrentStatus = MediaStatus.Paused;   // пауза видео
                                                        //vlcControl1.Time = trackBar1.Value * 1000;
                var media = vlcControl1.VlcMediaPlayer.GetMedia();
                media.Parse();
                vlcControl1.Position = (float)(trackBar1.Value / media.Duration.TotalSeconds);

                UpdateStatusBar();
                UpdateToolBar();


                //m_objMediaPosition.CurrentPosition = trackBar1.Value;   // перемещение позиции видео
            }
            catch { }
        }

        private void boldButton_Click(object sender, EventArgs e)
        {
            int start = editedSubTextBox.SelectionStart;
            TextStyleInsert("\\b1", "\\b0");
            editedSubTextBox.SelectionStart = start;
        }

        private void fontsizeButton_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                int start = editedSubTextBox.SelectionStart;
                TextStyleInsert("\\fn" + fontDialog1.Font.Name, 3);
                editedSubTextBox.SelectionStart = start;

                TextStyleInsert("\\fs" + fontDialog1.Font.Size, 3);
                editedSubTextBox.SelectionStart = start;

                if (fontDialog1.Font.Bold) TextStyleInsert("\\b1", 2);
                else TextStyleInsert("\\b0", 2);
                editedSubTextBox.SelectionStart = start;

                if (fontDialog1.Font.Italic) TextStyleInsert("\\i1", 2);
                else TextStyleInsert("\\i0", 2);
                editedSubTextBox.SelectionStart = start;

                if (fontDialog1.Font.Bold) TextStyleInsert("\\u1", 2);
                else TextStyleInsert("\\u0", 2);
                editedSubTextBox.SelectionStart = start;
            }
        }

        public void TextStyleInsert(string defaultStr, string replaceStr) // когда замена не требуется. используются кодовые слова из двух символов. Пример: \\fnArial
        {
            int beginIndex = 0;
            int endIndex = 0;
            if (editedSubTextBox.SelectionStart > 0)
            {
                endIndex = editedSubTextBox.Text.IndexOf('}', editedSubTextBox.SelectionStart - 1);
            }
            else
            {
                endIndex = editedSubTextBox.Text.IndexOf('}', editedSubTextBox.SelectionStart);
            }

            for (int i = endIndex; i >= 0; i--)
            {
                if (editedSubTextBox.Text[i] == '{')
                {
                    beginIndex = i + 1;
                    break;
                }
            }

            if (((editedSubTextBox.SelectionStart >= beginIndex && editedSubTextBox.SelectionStart <= endIndex) ||
                editedSubTextBox.SelectionStart + 1 == beginIndex || editedSubTextBox.SelectionStart - 1 == endIndex) &&
                beginIndex != -1 && endIndex != -1)
            {
                string subString;
                subString = editedSubTextBox.Text.Substring(beginIndex, endIndex - beginIndex);  // {...}

                if (subString.Contains(defaultStr))  // \b1
                {
                    subString = subString.Replace(defaultStr, replaceStr);    // replace
                    editedSubTextBox.Text = editedSubTextBox.Text.Remove(beginIndex, endIndex - beginIndex).Insert(beginIndex, subString);    // replace in text
                }
                else if (subString.Contains(replaceStr))    // \b0
                {
                    subString = subString.Replace(replaceStr, defaultStr);    // replace
                    editedSubTextBox.Text = editedSubTextBox.Text.Remove(beginIndex, endIndex - beginIndex).Insert(beginIndex, subString);    // replace in text
                }
                else editedSubTextBox.Text = editedSubTextBox.Text.Insert(endIndex, defaultStr);  // insert \b1
            }
            else editedSubTextBox.Text = editedSubTextBox.Text.Insert(editedSubTextBox.SelectionStart, "{" + defaultStr + "}"); // insert {\b1}
        }

        public void TextStyleInsert(string str, int num)
        {
            int beginIndex = 0;
            int endIndex = 0;
            if (str.Contains("frz") || str.Contains("pos"))
            {
                endIndex = editedSubTextBox.Text.IndexOf('}', 0);
            }
            else if (editedSubTextBox.SelectionStart > 0)
                endIndex = editedSubTextBox.Text.IndexOf('}', editedSubTextBox.SelectionStart - 1);
            else
                endIndex = editedSubTextBox.Text.IndexOf('}', editedSubTextBox.SelectionStart);

            for (int i = endIndex; i >= 0; i--)
            {
                if (editedSubTextBox.Text[i] == '{')
                {
                    beginIndex = i + 1;
                    break;
                }
            }

            if ((editedSubTextBox.SelectionStart >= beginIndex && editedSubTextBox.SelectionStart <= endIndex) ||
                editedSubTextBox.SelectionStart + 1 == beginIndex || editedSubTextBox.SelectionStart - 1 == endIndex &&
                beginIndex != -1 && endIndex != -1)
            {
                string subString;
                subString = editedSubTextBox.Text.Substring(beginIndex, endIndex - beginIndex);  // {...}

                if (subString.Contains(str.Substring(0, num)))  // \fs
                {
                    int index = subString.IndexOf(str.Substring(0, num));   // index of \fs
                    int next = subString.IndexOf("\\", index + 1);  // index of \fs20\fn...

                    if (next != -1)
                    {
                        subString = subString.Replace(subString.Substring(index + num, next - index - num), str.Substring(num));    // replace
                        editedSubTextBox.Text = editedSubTextBox.Text.Remove(beginIndex, endIndex - beginIndex).Insert(beginIndex, subString);    // replace in text
                    }
                    else
                    {
                        subString = subString.Replace(subString.Substring(index + num, subString.Length - index - num), str.Substring(num));
                        editedSubTextBox.Text = editedSubTextBox.Text.Remove(beginIndex, endIndex - beginIndex).Insert(beginIndex, subString);
                    }
                }
                else editedSubTextBox.Text = editedSubTextBox.Text.Insert(endIndex, str);
            }
            else editedSubTextBox.Text = editedSubTextBox.Text.Insert(editedSubTextBox.SelectionStart, "{" + str + "}");
        }

        private void cursiveButton_Click(object sender, EventArgs e)
        {
            int start = editedSubTextBox.SelectionStart;
            TextStyleInsert("\\i1", "\\i0");
            editedSubTextBox.SelectionStart = start;
        }

        private void underlineButton_Click(object sender, EventArgs e)
        {
            int start = editedSubTextBox.SelectionStart;
            TextStyleInsert("\\u1", "\\u0");
            editedSubTextBox.SelectionStart = start;
        }

        private void strikeoutButton_Click(object sender, EventArgs e)
        {
            int start = editedSubTextBox.SelectionStart;
            TextStyleInsert("\\s1", "\\s0");
            editedSubTextBox.SelectionStart = start;
        }

        public void loadStyle(Subtitle subtitles, ComboBox st)
        {
            st.Items.Clear();

            try
            {
                foreach (string name in subtitles.style)
                {
                    string[] nameSplit = name.Split(',');
                    st.Items.Add(nameSplit[0]);
                }
            }
            catch
            { }
        }

        private void DataGridView_DataLoad(Subtitle sub, DataGridView grid, ComboBox st)
        {
            loadStyle(sub, st);

            string[] textFormatSplit = sub.TextFormat.Split(','); // удаление Format: + удаление пробелов
            grid.Rows.Clear();

            for (int j = 0; j < sub.text.Count; j++)
            {
                grid.Rows.Add();
                subDataGridView.Rows[j].Cells[0].Value = j + 1;
                string[] textSplit = sub.text[j].Split(new char[] { ',' }, textFormatSplit.Length);
                for (int i = 0, k = 0; i < textFormatSplit.Count(); i++, k++)
                {
                    switch (textFormatSplit[i].Trim(' '))
                    {
                        case "Layer":
                            grid.Rows[j].Cells[1].Value = textSplit[k];
                            break;
                        case "Start":
                            if (textSplit[k] != "")
                                grid.Rows[j].Cells[2].Value = textSplit[k];
                            else
                                grid.Rows[j].Cells[2].Value = "00:00:00.000";
                            break;
                        case "End":
                            if (textSplit[k] != "")
                                grid.Rows[j].Cells[3].Value = textSplit[k];
                            else
                                grid.Rows[j].Cells[3].Value = "00:00:05.000";
                            break;
                        case "Style":
                            grid.Rows[j].Cells[4].Value = textSplit[k];
                            break;
                        case "Name":
                            grid.Rows[j].Cells[5].Value = textSplit[k];
                            break;
                        case "Effect":
                            grid.Rows[j].Cells[6].Value = textSplit[k];
                            break;
                        case "MarginL":
                            grid.Rows[j].Cells[7].Value = textSplit[k];
                            break;
                        case "MarginR":
                            grid.Rows[j].Cells[8].Value = textSplit[k];
                            break;
                        case "MarginV":
                            grid.Rows[j].Cells[9].Value = textSplit[k];
                            break;
                        case "Text":
                            if (k + 1 < textSplit.Length)
                            {
                                grid.Rows[j].Cells[10].Value = textSplit[k] + ",";

                            }
                            else grid.Rows[j].Cells[10].Value = textSplit[k];
                            break;
                    }
                }
            }
        }

        private void openSubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "All Files|*.*"
            };

            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                vlcControl1.Stop();
                m_CurrentStatus = MediaStatus.Stopped;
                UpdateStatusBar();
                UpdateToolBar();

                subFileName = openFileDialog.FileName;
                pluginBase.subtitles.setSubtitleString(subFormats.SelectFormat(subFileName, "", true));
                rowIndex = -1;
                DataGridView_DataLoad(pluginBase.subtitles, subDataGridView, styleComboBox);
                subDataGridView.Rows[0].Selected = true;
                subDataGridView.CurrentCell = subDataGridView.Rows[0].Cells[0];
                GridSelect();
                rowIndex = 0;


                try
                {
                    this.panelVideo.Controls.Remove(this.panelVideo.Controls.Find("vlcControl1", false)[0]);
                }
                catch { }

                vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
                vlcControl1.BeginInit();
                this.vlcControlPanel.Controls.Add(vlcControl1);
                this.vlcControl1.BringToFront();
                this.vlcControl1.BackColor = System.Drawing.Color.Black;
                this.vlcControl1.Location = new System.Drawing.Point(37, 4);
                this.vlcControl1.Name = "vlcControl1";
                this.vlcControl1.Size = new System.Drawing.Size(426, 240);
                this.vlcControl1.Dock = DockStyle.Fill;
                this.vlcControl1.Spu = -1;
                this.vlcControl1.TabIndex = 6;
                this.vlcControl1.Text = "vlcControl1";
                this.vlcControl1.VlcLibDirectory = null;
                vlcControl1.VlcMediaplayerOptions = new string[] { @"--sub-file=" + subFileName, "--no-sub-autodetect-file", "--sub-autodetect-fuzzy=1" };
                this.vlcControl1.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl_VlcLibDirectoryNeeded);
                vlcControl1.EndInit();
                //Controls.Add(vlcControl1);


                this.vlcControl1.SetMedia(@"file:///" + videoFileName);
                m_CurrentStatus = MediaStatus.Running;
                vlcControl1.Play();
                UpdateStatusBar();
                UpdateToolBar();
                System.Threading.Thread.Sleep(100);
                // this.vlcControl1.VlcMediaplayerOptions = new string[] { @"--sub-file=file:///" + openFileDialog.FileName, "--no-sub-autodetect-file", "--sub-autodetect-fuzzy=1" };

            }
        }

        private void originalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (originalCheckBox.Checked)
            {
                editedSubTextBox.Dock = DockStyle.Bottom;
                originalSubTextBox.Show();
            }
            else
            {
                editedSubTextBox.Dock = DockStyle.Fill;
                originalSubTextBox.Hide();
            }
        }

        private void changeStyleButton_Click(object sender, EventArgs e)
        {
            StyleSettingsForm ssForm = new StyleSettingsForm();//styleCombobox
            int index = 0;
            string inputStyle = "";
            foreach (string s in pluginBase.subtitles.style)
            {
                string[] sSplit = s.Split(',');
                for (int i = 0; i < sSplit.Length; i++)
                {
                    if (sSplit[i] == styleComboBox.Text)
                        inputStyle = s;
                }
                if (s != "")
                    break;
                index++;
            }

            ssForm.LoadForm(pluginBase.subtitles.style[index], pluginBase.subtitles.stylesFormat, index, pluginBase.subtitles);
            ssForm.ShowDialog();

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double x1 = 1, x2 = 1;
            SettingsForm setForm = new SettingsForm();
            if (FileNamePath != null && FileNamePath != "")
            {
                x1 = vlcControl1.Height;
                x2 = vlcControl1.Width;
            }
            setForm.LoadSettings(pluginBase.subtitles, x1, x2, subDataGridView, FileNamePath != "" ? true : false, FileNamePath, true);
            setForm.ShowDialog();

            loadStylesInComboBox();
        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            trackBarIsMoving = true;
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            trackBarIsMoving = false;
        }

        public void ShowErrorMessage(string ErrorMessage)
        {
            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(ErrorMessage);
            }
        }

        private void stylesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StyleListForm slForm = new StyleListForm();
            slForm.LoadForm(pluginBase, subDataGridView);
            if (slForm.ShowDialog() == DialogResult.OK)
            {
                loadStyle(pluginBase.subtitles, styleComboBox);
            }
        }

        private void effectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EffectsForm effectsForm = new EffectsForm();
            effectsForm.Show();
        }

        private void putInMSWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();

            //Статус приложения видимое или нет 
            winword.Visible = true;

            winword.WindowState = WdWindowState.wdWindowStateNormal;

            //Создание "Отсутствующей" переменной
            object missing = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word.Document document = winword.Documents.Add();
            document.Activate();

            //Добавление текста 
            Paragraph paragraph = document.Paragraphs.Add();
            document.Content.SetRange(0, 0);
            document.Content.Text = "";
            for (int i = 0; i < subDataGridView.RowCount; i++)
            {
                document.Content.Text += subDataGridView.Rows[i].Cells[0].Value.ToString();
                document.Content.Text += subDataGridView.Rows[i].Cells[10].Value.ToString() + Environment.NewLine + Environment.NewLine;
            }
        }

        private void subDataGridViewSave()
        {
            try
            {
                //dataGridView1.CurrentRow.Cells[10].Value = editedSubTextBox.Text;
                if (subDataGridView.Rows[rowIndex].Cells[1].Value.ToString() != levelDomainUpDown.Value.ToString())
                {
                    subDataGridView.Rows[rowIndex].Cells[1].Value = levelDomainUpDown.Value;
                    subChanged = true;
                }
                if (subDataGridView.Rows[rowIndex].Cells[2].Value.ToString() != beginTextBox.Text)
                {
                    subDataGridView.Rows[rowIndex].Cells[2].Value = beginTextBox.Text;
                    subChanged = true;
                }
                if (subDataGridView.Rows[rowIndex].Cells[3].Value.ToString() != endTextBox.Text)
                {
                    subDataGridView.Rows[rowIndex].Cells[3].Value = endTextBox.Text;
                    subChanged = true;
                }
                if (subDataGridView.Rows[rowIndex].Cells[4].Value.ToString() != styleComboBox.Text)
                {
                    subDataGridView.Rows[rowIndex].Cells[4].Value = styleComboBox.Text;
                    subChanged = true;
                }
                if (actorComboBox.Text != "Актер" && subDataGridView.Rows[rowIndex].Cells[5].Value.ToString() != actorComboBox.Text)
                {
                    subDataGridView.Rows[rowIndex].Cells[5].Value = actorComboBox.Text;
                    subChanged = true;
                }
                if (effectComboBox.Text != "Эффект" && subDataGridView.Rows[rowIndex].Cells[6].Value.ToString() != effectComboBox.Text)
                {
                    subDataGridView.Rows[rowIndex].Cells[6].Value = effectComboBox.Text;
                    subChanged = true;
                }
                if (subDataGridView.Rows[rowIndex].Cells[7].Value.ToString() != leftMaskedTextBox.Text)
                {
                    subDataGridView.Rows[rowIndex].Cells[7].Value = leftMaskedTextBox.Text;
                    subChanged = true;
                }
                if (subDataGridView.Rows[rowIndex].Cells[8].Value.ToString() != rightMaskedTextBox.Text)
                {
                    subDataGridView.Rows[rowIndex].Cells[8].Value = rightMaskedTextBox.Text;
                    subChanged = true;
                }
                if (subDataGridView.Rows[rowIndex].Cells[9].Value.ToString() != vertMaskedTextBox.Text)
                {
                    subDataGridView.Rows[rowIndex].Cells[9].Value = vertMaskedTextBox.Text;
                    subChanged = true;
                }
                if (subDataGridView.Rows[rowIndex].Cells[10].Value.ToString() != editedSubTextBox.Text)
                {
                    subDataGridView.Rows[rowIndex].Cells[10].Value = editedSubTextBox.Text;
                    subChanged = true;
                }
                if (m_CurrentStatus == MediaStatus.Running)
                    vlcControl1.Pause();

                subDataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = tableDefaultColor;
                
                rowIndex = subDataGridView.CurrentRow.Index;

                m_CurrentStatus = MediaStatus.Paused;   // пауза видео
                                                        //vlcControl1.Time = trackBar1.Value * 1000;
                var media = vlcControl1.VlcMediaPlayer.GetMedia();
                media.Parse();
                vlcControl1.Position = (float)((TimeSpan.Parse(subDataGridView.Rows[subDataGridView.CurrentRow.Index].Cells[2].Value.ToString()).TotalSeconds - 1) / media.Duration.TotalSeconds);

                UpdateStatusBar();
                UpdateToolBar();
            }
            catch { }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            subDataGridViewSave();
            if (subChanged) RefreshVideoSub();
        }

        private void videoSubOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoSubOnlyToolStripMenuItem.Checked = true;
            subOnlyToolStripMenuItem.Checked = false;

            panelVideo.Show();
            panelTable.Height = 250;
            panelSubChange.Dock = DockStyle.Right;
        }

        private void subOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoSubOnlyToolStripMenuItem.Checked = false;
            subOnlyToolStripMenuItem.Checked = true;

            panelVideo.Hide();
            panelTable.Height = 430;
            panelSubChange.Dock = DockStyle.Fill;
        }

        private void inputStylesInToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolBar2_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (toolBar2.Buttons.IndexOf(e.Button))
            {
                case 0:
                    VideoPictureBoxCreate();
                    break;
                case 1:
                    SubLocationMove();
                    break;
                case 2:
                    SubRotationChange();
                    break;
            }
        }

        private string VideoCoordinates(int x, int y)
        {
            double numX = (double)Convert.ToInt32(pluginBase.subtitles.playResX) / (double)vlcControl1.Width;// множитель X
            double numY = (double)Convert.ToInt32(pluginBase.subtitles.playResY) / (double)vlcControl1.Height;// множитель Y

            return ((int)(x * numX)).ToString() + "," + ((int)(y * numY)).ToString();
        }

        private void Element_MouseMove(object sender, MouseEventArgs e)
        {    
            vlcControlPanel.Controls[2].Visible = true;
            vlcControlPanel.Controls[1].Visible = true;
            vlcControlPanel.Controls[0].Visible = true;

            vlcControlPanel.Controls[2].Location = new System.Drawing.Point(e.Location.X, 0);

            vlcControlPanel.Controls[1].Location = new System.Drawing.Point(0, e.Location.Y);

            vlcControlPanel.Controls[0].Location = new System.Drawing.Point(e.Location.X + 15, e.Location.Y + 15);
            vlcControlPanel.Controls[0].Text = VideoCoordinates(e.Location.X, e.Location.Y);
            //vlcControl1.Controls[vlcControl1.Controls.Count - 1].MouseMove -= new MouseEventHandler(this.Element_MouseMove);
            //vlcControl1.Controls[vlcControl1.Controls.Count - 1].MouseMove += new MouseEventHandler(this.Element_MouseMove);
        }

        private void Element_MouseLeave(object sender, EventArgs e)
        {
            if (this.ActiveControl != vlcControlPanel.Controls[0] ||
                this.ActiveControl != vlcControlPanel.Controls[1] ||
                this.ActiveControl != vlcControlPanel.Controls[2] ||
                this.ActiveControl != vlcControl1.Controls[vlcControl1.Controls.Count - 1])
            {
                vlcControlPanel.Controls[2].Visible = false;
                vlcControlPanel.Controls[1].Visible = false;
                vlcControlPanel.Controls[0].Visible = false;
            }
        }

        private void Element_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x, y;
                string[] str = vlcControlPanel.Controls[0].Text.Split(',');
                x = Convert.ToInt32(str[0]);
                y = Convert.ToInt32(str[1]);
                TextStyleInsert("\\pos(" + str[0] + "," + str[1] + ")", 5);
            }
        }

        private void VideoPictureBoxCreate()
        {
            if (vlcControlPanel.Controls.Count >= 4 || toolBar2.Buttons[0].Pushed)
            {
                try
                {
                    toolBar2.Buttons[0].Pushed = false;
                    this.vlcControlPanel.Controls.Remove(this.vlcControlPanel.Controls.Find("p1", false)[0]);
                    this.vlcControlPanel.Controls.Remove(this.vlcControlPanel.Controls.Find("p2", false)[0]);
                    this.vlcControlPanel.Controls.Remove(this.vlcControlPanel.Controls.Find("labelVideo", false)[0]);
                    this.vlcControl1.Controls.Remove(this.vlcControl1.Controls.Find("videoPictureBox", false)[0]);
                }
                catch { }
            }
            else
            {

                Panel p1 = new Panel();
                Panel p2 = new Panel();
                Label l = new Label();
                Button b = new Button();
                PictureBox pb = new PictureBox();    

                p1.Height = vlcControl1.Height;
                p1.Width = 1;
                p1.Name = "p1";
                p1.BackColor = Color.White;
                //vlcControl1.Controls.Add(p1);
                //vlcControl1.Controls[vlcControl1.Controls.Count - 1].BringToFront();
                vlcControlPanel.Controls.Add(p1);
                vlcControlPanel.Controls[vlcControlPanel.Controls.Count - 1].BringToFront();

                p2.Height = 1;
                p2.Width = vlcControl1.Width;
                p2.Name = "p2";
                p2.BackColor = Color.White;
                //vlcControl1.Controls.Add(p2);
                //vlcControl1.Controls[vlcControl1.Controls.Count - 1].BringToFront();
                vlcControlPanel.Controls.Add(p2);
                vlcControlPanel.Controls[vlcControlPanel.Controls.Count - 1].BringToFront();

                l.Name = "labelVideo";
                l.BackColor = Color.Transparent;
                l.ForeColor = Color.Red;
                l.Font = new System.Drawing.Font("Arial", l.Font.Size + 2);
                l.Width = 80;
                //vlcControl1.Controls.Add(l);
                //vlcControl1.Controls[vlcControl1.Controls.Count - 1].BringToFront();
                vlcControlPanel.Controls.Add(l);
                vlcControlPanel.Controls[vlcControlPanel.Controls.Count - 1].BringToFront();

                pb.Name = "videoPictureBox";
                pb.BackColor = Color.Transparent;
                pb.Height = vlcControl1.Height;
                pb.Width = vlcControl1.Width;
                pb.Location = new System.Drawing.Point(0, 0);
                pb.MouseMove += new MouseEventHandler(this.Element_MouseMove);
                pb.MouseLeave += new EventHandler(this.Element_MouseLeave);
                pb.Dock = DockStyle.Fill;
                vlcControl1.Controls.Add(pb);

                toolBar2.Buttons[0].Pushed = true;
            }
        }

        private void findSubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindChangeForm fcForm = new FindChangeForm();
            fcForm.LoadForm(subDataGridView);
            fcForm.Show();
        }

        private void editedSubTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl != null)
                if (this.ActiveControl.Name == editedSubTextBox.Name)
                {
                    if (!isStarted)
                    {
                        position = editedSubTextBox.SelectionStart;
                        timer2.Start();
                        buffer = editedSubTextBox.Text;
                        isStarted = true;
                    }
                }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            string bufferNew = editedSubTextBox.Text;
            if (buffer.Length < bufferNew.Length)
            {
                buffer = bufferNew.Replace(buffer, "");
                editSubClass.EditListAdd(editedSubTextBox.Name, "Ввод", position, buffer);
            }
            else if (buffer.Length > bufferNew.Length)
            {
                position = editedSubTextBox.SelectionStart;
                buffer = buffer.Replace(bufferNew, "");
                editSubClass.EditListAdd(editedSubTextBox.Name, "Удаление", position, buffer);
            }
            isStarted = false;
        }

        private void renumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableReNum(subDataGridView);
        }

        private void sortAndRenumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableSort();

            subDataGridView.Rows.Clear();
            for (int i = 0; i < subDataGridView.Rows.Count; i++)
            {
                subDataGridView.Rows.Add(tableSortList[i].row);
            }

            tableReNum(subDataGridView);
        }

        public void TableSort()
        {
            try
            {
                if (tableSortList != null)
                {
                    tableSortList.Clear();
                    for (int i = 0; i < subDataGridView.RowCount; i++)
                    {
                        tableSortList.Add(new tableSort()
                        {
                            num = i,
                            row = subDataGridView.Rows[i],
                            begin = TimeSpan.Parse(subDataGridView.Rows[i].Cells[2].Value.ToString()),
                            end = TimeSpan.Parse(subDataGridView.Rows[i].Cells[3].Value.ToString())
                        });
                    }
                    tableSortList.Sort((x, y) => x.begin.TotalMilliseconds.CompareTo(y.end.TotalMilliseconds));
                }
            }
            catch { }
        }

        private void selectCrossedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isSelectedCrossed)
            {
                TableSort();
                for (int i = 0; i < subDataGridView.Rows.Count; i++)
                {
                    for (int j = i + 1; j < subDataGridView.Rows.Count; j++)
                    {
                        if (tableSortList[i].begin > tableSortList[j].begin)
                        {
                            subDataGridView.Rows[tableSortList[i].num].DefaultCellStyle.ForeColor = Color.Red;
                            subDataGridView.Rows[tableSortList[j].num].DefaultCellStyle.ForeColor = Color.Red;
                            isSelectedCrossed = true;
                        }
                        else if (tableSortList[i].end > tableSortList[j].end)
                        {
                            subDataGridView.Rows[tableSortList[i].num].DefaultCellStyle.ForeColor = Color.Red;
                            subDataGridView.Rows[tableSortList[j].num].DefaultCellStyle.ForeColor = Color.Red;
                            isSelectedCrossed = true;
                        };
                    }
                }
            }
            else
            {
                for (int i = 0; i < subDataGridView.Rows.Count; i++)
                {
                    subDataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
                isSelectedCrossed = false;
            }
        }

        private void deleteTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить все теги?", "Удалить теги?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string str = "";
                for (int i = 0; i < subDataGridView.Rows.Count; i++)
                {
                    string[] strSplit = subDataGridView.Rows[i].Cells[10].Value.ToString().Split('{');
                    if (strSplit.Length > 2)
                    {
                        for (int j = 0; j < strSplit.Length; j++)
                        {
                            strSplit[j] = strSplit[j].Split('}')[1];
                            str += strSplit[j];
                        }
                    }
                    else str = strSplit[0];
                }
            }
        }

        private void clearTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = "";
            for (int i = 0; i < subDataGridView.Rows.Count; i++)
            {
                string[] strSplit = subDataGridView.Rows[i].Cells[10].Value.ToString().Split('{');
                if (strSplit.Length > 2)
                {
                    for (int j = 0; j < strSplit.Length; j++)
                    {

                    }
                }
                else str = strSplit[0];
            }
        }

        private void saveSubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            subFormats.SelectFormat(subFileName, pluginBase.subtitles.getSubtitlesString(), false);
        }

        private void saveAsSubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "All Files|*.*"
            };

            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
                subFormats.SelectFormat(saveFileDialog.FileName, pluginBase.subtitles.getSubtitlesString(), false);
            }
        }

        private void newSubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (subFileName != null && subFileName != "")
            {
                if (MessageBox.Show("Сохранить сценарий?", "Сохранение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveFile();
                }
            }
            subFileName = "Default.ass";
            NewLoad();
        }

        private void сместитьВремяНаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveTimeForm mtForm = new MoveTimeForm();
            mtForm.LoadForm(subDataGridView);
            mtForm.Show();
        }

        private void volumeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (FileNamePath != "" && FileNamePath != null)
            {
                var media = vlcControl1.VlcMediaPlayer.GetMedia();
                media.Parse();
                float time = (float)(trackBar1.Value / media.Duration.TotalSeconds);
                vlcControl1.Stop();
                vlcControl1.Audio.Volume = volumeTrackBar.Value;
                vlcControl1.Position = time;
                vlcControl1.Play();
            }
        }

        private void cancelSubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Keys keyData = new Keys();
            keyData = Keys.Control | Keys.Z;
            Message message = new Message();
            message.Msg = WM_KEYDOWN;
            ProcessCmdKey(ref message, keyData);
        }

        private void backSubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Keys keyData = new Keys();
            keyData = Keys.Control | Keys.Y;
            Message message = new Message();
            message.Msg = WM_KEYDOWN;
            ProcessCmdKey(ref message, keyData);
        }

        private void cutSubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Keys keyData = new Keys();
            keyData = Keys.Control | Keys.X;
            Message message = new Message();
            message.Msg = WM_KEYDOWN;
            ProcessCmdKey(ref message, keyData);
        }

        private void copySubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Keys keyData = new Keys();
            keyData = Keys.Control | Keys.C;
            Message message = new Message();
            message.Msg = WM_KEYDOWN;
            ProcessCmdKey(ref message, keyData);
        }

        private void putSubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Keys keyData = new Keys();
            keyData = Keys.Control | Keys.V;
            Message message = new Message();
            message.Msg = WM_KEYDOWN;
            ProcessCmdKey(ref message, keyData);
        }

        private void deleteSubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Keys keyData = new Keys();
            keyData = Keys.Delete;
            Message message = new Message();
            message.Msg = WM_KEYDOWN;
            ProcessCmdKey(ref message, keyData);
        }

        private void closeVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanUp();
        }

        private void SubLocationMove()
        {
            if (vlcControlPanel.Controls.Count >= 4)
            {
                if ((this.vlcControl1.Controls.Find("videoPictureBox", false).Length > 0))
                {
                    if (!toolBar2.Buttons[1].Pushed)
                    {
                        vlcControlPanel.Controls[2].MouseDown += new MouseEventHandler(this.Element_MouseDown);
                        vlcControlPanel.Controls[1].MouseDown += new MouseEventHandler(this.Element_MouseDown);
                        vlcControlPanel.Controls[0].MouseDown += new MouseEventHandler(this.Element_MouseDown);
                        vlcControl1.Controls[vlcControl1.Controls.Count - 1].MouseDown += new MouseEventHandler(this.Element_MouseDown);
                        toolBar2.Buttons[1].Pushed = true;
                    }
                    else
                    {
                        vlcControlPanel.Controls[2].MouseDown -= new MouseEventHandler(this.Element_MouseDown);
                        vlcControlPanel.Controls[1].MouseDown -= new MouseEventHandler(this.Element_MouseDown);
                        vlcControlPanel.Controls[0].MouseDown -= new MouseEventHandler(this.Element_MouseDown);
                        vlcControl1.Controls[vlcControl1.Controls.Count - 1].MouseDown -= new MouseEventHandler(this.Element_MouseDown);
                        toolBar2.Buttons[1].Pushed = false;
                    }
                }
            }
        }

        private void SubRotationChange()
        {
            RotationChange rcForm = new RotationChange();
            int rotation;
            if (rcForm.ShowDialog() == DialogResult.OK)
            {
                rotation = rcForm.rotationNumber;
                rcForm.Close();
                string str = "\\frz" + rotation.ToString();
                TextStyleInsert(str, 4);
            }
        }

        private void RefreshVideoSub()
        {
            try
            {
                string str;
                pluginBase.subtitles.text.Clear();
                for (int i = 0; i < subDataGridView.Rows.Count; i++)
                {
                    str = RowToString(subDataGridView.Rows[i]);
                    str = str.Split(new string[] { ":" }, 2, StringSplitOptions.None)[1].Trim();
                    pluginBase.subtitles.text.Add(str);
                }
            }
            catch { }

            subFormats.SelectFormat("subTmpFile.ssa", pluginBase.subtitles.getSubtitlesString(), false);

            CleanUp();

            try
            {
                this.vlcControlPanel.Controls.Remove(this.vlcControlPanel.Controls.Find("vlcControl1", false)[0]);
            }
            catch { }

            vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
            vlcControl1.BeginInit();
            this.vlcControlPanel.Controls.Add(vlcControl1);
            this.vlcControl1.BringToFront();
            this.vlcControl1.BackColor = System.Drawing.Color.Black;
            this.vlcControl1.Location = new System.Drawing.Point(37, 4);
            this.vlcControl1.Name = "vlcControl1";
            this.vlcControl1.Size = new System.Drawing.Size(426, 240);
            this.vlcControl1.Dock = DockStyle.Fill;
            this.vlcControl1.Spu = -1;
            this.vlcControl1.TabIndex = 6;
            this.vlcControl1.Text = "vlcControl1";
            this.vlcControl1.VlcLibDirectory = null;
            //if (subFileName != null && subFileName != "") vlcControl1.VlcMediaplayerOptions = new string[] { @"--sub-file=" + subFileName, "--no-sub-autodetect-file", "--sub-autodetect-fuzzy=1" };
            vlcControl1.VlcMediaplayerOptions = new string[] { @"--sub-file=" + "subTmpFile.ssa", "--no-sub-autodetect-file", "--sub-autodetect-fuzzy=1" };
            this.vlcControl1.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl_VlcLibDirectoryNeeded);
            vlcControl1.EndInit();
            //Controls.Add(vlcControl1);


            this.vlcControl1.SetMedia(@"file:///" + videoFileName);
            m_CurrentStatus = MediaStatus.Running;
            vlcControl1.Play();
            UpdateStatusBar();
            UpdateToolBar();

            timer1.Start();

            subChanged = false;
        }

        private void toolBar3_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (toolBar3.Buttons.IndexOf(e.Button))
            {
                case 0:
                    
                    break;

                case 1:
                    
                    break;

                case 2:
                    
                    break;
                case 3:

                    break;
                case 4:
                    RefreshVideoSub();
                    break;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Сделал: Харсекин И.Р. БПИ17-01", "Помощь");
        }
    }
}
