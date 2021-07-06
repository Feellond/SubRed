using System;
using System.IO;

namespace SubRed
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsSubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelSubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backSubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutSubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.putSubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.findSubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stylesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.effectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сместитьВремяНаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.putInMSWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortAndRenumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.автоматизацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectCrossedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findAndChangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoSubOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTable = new System.Windows.Forms.Panel();
            this.subDataGridView = new System.Windows.Forms.DataGridView();
            this.numberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.beginColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.styleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.effectColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vertColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelVideo = new System.Windows.Forms.Panel();
            this.vlcControlPanel = new System.Windows.Forms.Panel();
            this.vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
            this.toolBar2 = new System.Windows.Forms.ToolBar();
            this.coordToolBarButton = new System.Windows.Forms.ToolBarButton();
            this.moveToolBarButton = new System.Windows.Forms.ToolBarButton();
            this.rotateToolBarButton = new System.Windows.Forms.ToolBarButton();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBarPanel = new System.Windows.Forms.Panel();
            this.toolBarPanel = new System.Windows.Forms.Panel();
            this.volumeTrackBar = new System.Windows.Forms.TrackBar();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.panelSubChange = new System.Windows.Forms.Panel();
            this.originalSubTextBox = new System.Windows.Forms.TextBox();
            this.editedSubTextBox = new System.Windows.Forms.TextBox();
            this.editSubFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.stylesPanel = new System.Windows.Forms.Panel();
            this.styleComboBox = new System.Windows.Forms.ComboBox();
            this.editStylesButtonPanel = new System.Windows.Forms.Panel();
            this.changeStyleButton = new System.Windows.Forms.Button();
            this.actorPanel = new System.Windows.Forms.Panel();
            this.actorComboBox = new System.Windows.Forms.ComboBox();
            this.effectButton = new System.Windows.Forms.Panel();
            this.effectComboBox = new System.Windows.Forms.ComboBox();
            this.editEffectButtonPanel = new System.Windows.Forms.Panel();
            this.changeEffectButton = new System.Windows.Forms.Button();
            this.numPanel = new System.Windows.Forms.Panel();
            this.levelDomainUpDown = new System.Windows.Forms.NumericUpDown();
            this.marginPanel = new System.Windows.Forms.Panel();
            this.leftMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.rightMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.vertMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.timePanel = new System.Windows.Forms.Panel();
            this.beginTextBox = new System.Windows.Forms.TextBox();
            this.endTextBox = new System.Windows.Forms.TextBox();
            this.durationTextBox = new System.Windows.Forms.TextBox();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.boldButton = new System.Windows.Forms.Button();
            this.cursiveButton = new System.Windows.Forms.Button();
            this.underlineButton = new System.Windows.Forms.Button();
            this.strikeoutButton = new System.Windows.Forms.Button();
            this.fontsizeButton = new System.Windows.Forms.Button();
            this.originalPanel = new System.Windows.Forms.Panel();
            this.originalCheckBox = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolBar3 = new System.Windows.Forms.ToolBar();
            this.newSubToolBarButton = new System.Windows.Forms.ToolBarButton();
            this.openSubToolBarButton = new System.Windows.Forms.ToolBarButton();
            this.saveSubToolBarButton = new System.Windows.Forms.ToolBarButton();
            this.openVideoToolBarButton = new System.Windows.Forms.ToolBarButton();
            this.refreshToolBarButton = new System.Windows.Forms.ToolBarButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.panelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subDataGridView)).BeginInit();
            this.panelVideo.SuspendLayout();
            this.vlcControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).BeginInit();
            this.panel1.SuspendLayout();
            this.trackBarPanel.SuspendLayout();
            this.toolBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            this.panelSubChange.SuspendLayout();
            this.editSubFlowLayoutPanel.SuspendLayout();
            this.stylesPanel.SuspendLayout();
            this.editStylesButtonPanel.SuspendLayout();
            this.actorPanel.SuspendLayout();
            this.effectButton.SuspendLayout();
            this.editEffectButtonPanel.SuspendLayout();
            this.numPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelDomainUpDown)).BeginInit();
            this.marginPanel.SuspendLayout();
            this.timePanel.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.originalPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.videoToolStripMenuItem,
            this.subToolStripMenuItem,
            this.автоматизацияToolStripMenuItem,
            this.видToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1096, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSubToolStripMenuItem,
            this.openSubToolStripMenuItem,
            this.saveSubToolStripMenuItem,
            this.saveAsSubToolStripMenuItem,
            this.toolStripSeparator2,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // newSubToolStripMenuItem
            // 
            this.newSubToolStripMenuItem.Name = "newSubToolStripMenuItem";
            this.newSubToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.newSubToolStripMenuItem.Text = "Новые субтитры";
            this.newSubToolStripMenuItem.Click += new System.EventHandler(this.newSubToolStripMenuItem_Click);
            // 
            // openSubToolStripMenuItem
            // 
            this.openSubToolStripMenuItem.Name = "openSubToolStripMenuItem";
            this.openSubToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.openSubToolStripMenuItem.Text = "Открыть субтитры";
            this.openSubToolStripMenuItem.Click += new System.EventHandler(this.openSubToolStripMenuItem_Click);
            // 
            // saveSubToolStripMenuItem
            // 
            this.saveSubToolStripMenuItem.Name = "saveSubToolStripMenuItem";
            this.saveSubToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
            this.saveSubToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.saveSubToolStripMenuItem.Text = "Сохранить субтитры";
            this.saveSubToolStripMenuItem.Click += new System.EventHandler(this.saveSubToolStripMenuItem_Click);
            // 
            // saveAsSubToolStripMenuItem
            // 
            this.saveAsSubToolStripMenuItem.Name = "saveAsSubToolStripMenuItem";
            this.saveAsSubToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.saveAsSubToolStripMenuItem.Text = "Сохранить субтитры как...";
            this.saveAsSubToolStripMenuItem.Click += new System.EventHandler(this.saveAsSubToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(225, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.settingsToolStripMenuItem.Text = "Свойства";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(225, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelSubToolStripMenuItem,
            this.backSubToolStripMenuItem,
            this.toolStripSeparator1,
            this.cutSubToolStripMenuItem,
            this.copySubToolStripMenuItem,
            this.putSubToolStripMenuItem,
            this.deleteSubToolStripMenuItem,
            this.toolStripSeparator4,
            this.findSubToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.editToolStripMenuItem.Text = "Редактирование";
            // 
            // cancelSubToolStripMenuItem
            // 
            this.cancelSubToolStripMenuItem.Name = "cancelSubToolStripMenuItem";
            this.cancelSubToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Z";
            this.cancelSubToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.cancelSubToolStripMenuItem.Text = "Отменить";
            this.cancelSubToolStripMenuItem.Click += new System.EventHandler(this.cancelSubToolStripMenuItem_Click);
            // 
            // backSubToolStripMenuItem
            // 
            this.backSubToolStripMenuItem.Name = "backSubToolStripMenuItem";
            this.backSubToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Y";
            this.backSubToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.backSubToolStripMenuItem.Text = "Вернуть";
            this.backSubToolStripMenuItem.Click += new System.EventHandler(this.backSubToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // cutSubToolStripMenuItem
            // 
            this.cutSubToolStripMenuItem.Name = "cutSubToolStripMenuItem";
            this.cutSubToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+X";
            this.cutSubToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.cutSubToolStripMenuItem.Text = "Вырезать";
            this.cutSubToolStripMenuItem.Click += new System.EventHandler(this.cutSubToolStripMenuItem_Click);
            // 
            // copySubToolStripMenuItem
            // 
            this.copySubToolStripMenuItem.Name = "copySubToolStripMenuItem";
            this.copySubToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
            this.copySubToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.copySubToolStripMenuItem.Text = "Копировать";
            this.copySubToolStripMenuItem.Click += new System.EventHandler(this.copySubToolStripMenuItem_Click);
            // 
            // putSubToolStripMenuItem
            // 
            this.putSubToolStripMenuItem.Name = "putSubToolStripMenuItem";
            this.putSubToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V";
            this.putSubToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.putSubToolStripMenuItem.Text = "Вставить";
            this.putSubToolStripMenuItem.Click += new System.EventHandler(this.putSubToolStripMenuItem_Click);
            // 
            // deleteSubToolStripMenuItem
            // 
            this.deleteSubToolStripMenuItem.Name = "deleteSubToolStripMenuItem";
            this.deleteSubToolStripMenuItem.ShortcutKeyDisplayString = "Del";
            this.deleteSubToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.deleteSubToolStripMenuItem.Text = "Удалить";
            this.deleteSubToolStripMenuItem.Click += new System.EventHandler(this.deleteSubToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(188, 6);
            // 
            // findSubToolStripMenuItem
            // 
            this.findSubToolStripMenuItem.Name = "findSubToolStripMenuItem";
            this.findSubToolStripMenuItem.ShortcutKeyDisplayString = "F3";
            this.findSubToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.findSubToolStripMenuItem.Text = "Найти и заменить";
            this.findSubToolStripMenuItem.Click += new System.EventHandler(this.findSubToolStripMenuItem_Click);
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openVideoToolStripMenuItem,
            this.closeVideoToolStripMenuItem});
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.videoToolStripMenuItem.Text = "Видео";
            // 
            // openVideoToolStripMenuItem
            // 
            this.openVideoToolStripMenuItem.Name = "openVideoToolStripMenuItem";
            this.openVideoToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.openVideoToolStripMenuItem.Text = "Открыть видео...";
            this.openVideoToolStripMenuItem.Click += new System.EventHandler(this.openVideoToolStripMenuItem_Click);
            // 
            // closeVideoToolStripMenuItem
            // 
            this.closeVideoToolStripMenuItem.Name = "closeVideoToolStripMenuItem";
            this.closeVideoToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.closeVideoToolStripMenuItem.Text = "Закрыть видео";
            this.closeVideoToolStripMenuItem.Click += new System.EventHandler(this.closeVideoToolStripMenuItem_Click);
            // 
            // subToolStripMenuItem
            // 
            this.subToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stylesToolStripMenuItem,
            this.effectsToolStripMenuItem,
            this.сместитьВремяНаToolStripMenuItem,
            this.putInMSWordToolStripMenuItem,
            this.renumToolStripMenuItem,
            this.sortAndRenumToolStripMenuItem});
            this.subToolStripMenuItem.Name = "subToolStripMenuItem";
            this.subToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.subToolStripMenuItem.Text = "Субтитры";
            // 
            // stylesToolStripMenuItem
            // 
            this.stylesToolStripMenuItem.Name = "stylesToolStripMenuItem";
            this.stylesToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.stylesToolStripMenuItem.Text = "Стили...";
            this.stylesToolStripMenuItem.Click += new System.EventHandler(this.stylesToolStripMenuItem_Click);
            // 
            // effectsToolStripMenuItem
            // 
            this.effectsToolStripMenuItem.Name = "effectsToolStripMenuItem";
            this.effectsToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.effectsToolStripMenuItem.Text = "Эффекты...";
            this.effectsToolStripMenuItem.Click += new System.EventHandler(this.effectsToolStripMenuItem_Click);
            // 
            // сместитьВремяНаToolStripMenuItem
            // 
            this.сместитьВремяНаToolStripMenuItem.Name = "сместитьВремяНаToolStripMenuItem";
            this.сместитьВремяНаToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.сместитьВремяНаToolStripMenuItem.Text = "Сместить время на...";
            this.сместитьВремяНаToolStripMenuItem.Click += new System.EventHandler(this.сместитьВремяНаToolStripMenuItem_Click);
            // 
            // putInMSWordToolStripMenuItem
            // 
            this.putInMSWordToolStripMenuItem.Name = "putInMSWordToolStripMenuItem";
            this.putInMSWordToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.putInMSWordToolStripMenuItem.Text = "Передать текст фраз в MS Word";
            this.putInMSWordToolStripMenuItem.Click += new System.EventHandler(this.putInMSWordToolStripMenuItem_Click);
            // 
            // renumToolStripMenuItem
            // 
            this.renumToolStripMenuItem.Name = "renumToolStripMenuItem";
            this.renumToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.renumToolStripMenuItem.Text = "Перенумеровать";
            this.renumToolStripMenuItem.Click += new System.EventHandler(this.renumToolStripMenuItem_Click);
            // 
            // sortAndRenumToolStripMenuItem
            // 
            this.sortAndRenumToolStripMenuItem.Name = "sortAndRenumToolStripMenuItem";
            this.sortAndRenumToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.sortAndRenumToolStripMenuItem.Text = "Отсортировать и перенумеровать";
            this.sortAndRenumToolStripMenuItem.Click += new System.EventHandler(this.sortAndRenumToolStripMenuItem_Click);
            // 
            // автоматизацияToolStripMenuItem
            // 
            this.автоматизацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearTagToolStripMenuItem,
            this.deleteTagToolStripMenuItem,
            this.selectCrossedToolStripMenuItem,
            this.findAndChangeToolStripMenuItem});
            this.автоматизацияToolStripMenuItem.Name = "автоматизацияToolStripMenuItem";
            this.автоматизацияToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.автоматизацияToolStripMenuItem.Text = "Автоматизация";
            // 
            // clearTagToolStripMenuItem
            // 
            this.clearTagToolStripMenuItem.Name = "clearTagToolStripMenuItem";
            this.clearTagToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.clearTagToolStripMenuItem.Text = "Очистить теги";
            this.clearTagToolStripMenuItem.Click += new System.EventHandler(this.clearTagToolStripMenuItem_Click);
            // 
            // deleteTagToolStripMenuItem
            // 
            this.deleteTagToolStripMenuItem.Name = "deleteTagToolStripMenuItem";
            this.deleteTagToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.deleteTagToolStripMenuItem.Text = "Удаление тегов";
            this.deleteTagToolStripMenuItem.Click += new System.EventHandler(this.deleteTagToolStripMenuItem_Click);
            // 
            // selectCrossedToolStripMenuItem
            // 
            this.selectCrossedToolStripMenuItem.Name = "selectCrossedToolStripMenuItem";
            this.selectCrossedToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.selectCrossedToolStripMenuItem.Text = "Выделить пересечения";
            this.selectCrossedToolStripMenuItem.Click += new System.EventHandler(this.selectCrossedToolStripMenuItem_Click);
            // 
            // findAndChangeToolStripMenuItem
            // 
            this.findAndChangeToolStripMenuItem.Name = "findAndChangeToolStripMenuItem";
            this.findAndChangeToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.findAndChangeToolStripMenuItem.Text = "Проверить и исправить...";
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subOnlyToolStripMenuItem,
            this.videoSubOnlyToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // subOnlyToolStripMenuItem
            // 
            this.subOnlyToolStripMenuItem.Name = "subOnlyToolStripMenuItem";
            this.subOnlyToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.subOnlyToolStripMenuItem.Text = "Только субтитры";
            this.subOnlyToolStripMenuItem.Click += new System.EventHandler(this.subOnlyToolStripMenuItem_Click);
            // 
            // videoSubOnlyToolStripMenuItem
            // 
            this.videoSubOnlyToolStripMenuItem.Checked = true;
            this.videoSubOnlyToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.videoSubOnlyToolStripMenuItem.Name = "videoSubOnlyToolStripMenuItem";
            this.videoSubOnlyToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.videoSubOnlyToolStripMenuItem.Text = "Видео+субтитры";
            this.videoSubOnlyToolStripMenuItem.Click += new System.EventHandler(this.videoSubOnlyToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // panelTable
            // 
            this.panelTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTable.Controls.Add(this.subDataGridView);
            this.panelTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTable.Location = new System.Drawing.Point(0, 395);
            this.panelTable.Name = "panelTable";
            this.panelTable.Size = new System.Drawing.Size(1096, 250);
            this.panelTable.TabIndex = 1;
            // 
            // subDataGridView
            // 
            this.subDataGridView.AllowUserToAddRows = false;
            this.subDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.subDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.subDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.subDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.subDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberColumn,
            this.levelColumn,
            this.beginColumn,
            this.endColumn,
            this.styleColumn,
            this.actorColumn,
            this.effectColumn,
            this.leftColumn,
            this.rightColumn,
            this.vertColumn,
            this.textColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.subDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.subDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subDataGridView.EnableHeadersVisualStyles = false;
            this.subDataGridView.Location = new System.Drawing.Point(0, 0);
            this.subDataGridView.Name = "subDataGridView";
            this.subDataGridView.ReadOnly = true;
            this.subDataGridView.RowHeadersVisible = false;
            this.subDataGridView.Size = new System.Drawing.Size(1092, 246);
            this.subDataGridView.TabIndex = 0;
            this.subDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.subDataGridView.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.subDataGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // numberColumn
            // 
            this.numberColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.numberColumn.HeaderText = "#";
            this.numberColumn.Name = "numberColumn";
            this.numberColumn.ReadOnly = true;
            this.numberColumn.Width = 39;
            // 
            // levelColumn
            // 
            this.levelColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.levelColumn.HeaderText = "L";
            this.levelColumn.Name = "levelColumn";
            this.levelColumn.ReadOnly = true;
            this.levelColumn.Width = 38;
            // 
            // beginColumn
            // 
            this.beginColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.beginColumn.HeaderText = "Старт";
            this.beginColumn.Name = "beginColumn";
            this.beginColumn.ReadOnly = true;
            this.beginColumn.Width = 61;
            // 
            // endColumn
            // 
            this.endColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.endColumn.HeaderText = "Конец";
            this.endColumn.Name = "endColumn";
            this.endColumn.ReadOnly = true;
            this.endColumn.Width = 63;
            // 
            // styleColumn
            // 
            this.styleColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.styleColumn.HeaderText = "Стиль";
            this.styleColumn.Name = "styleColumn";
            this.styleColumn.ReadOnly = true;
            this.styleColumn.Width = 62;
            // 
            // actorColumn
            // 
            this.actorColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.actorColumn.HeaderText = "Актер";
            this.actorColumn.Name = "actorColumn";
            this.actorColumn.ReadOnly = true;
            this.actorColumn.Width = 62;
            // 
            // effectColumn
            // 
            this.effectColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.effectColumn.HeaderText = "Эффект";
            this.effectColumn.Name = "effectColumn";
            this.effectColumn.ReadOnly = true;
            this.effectColumn.Width = 72;
            // 
            // leftColumn
            // 
            this.leftColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.leftColumn.HeaderText = "Левое";
            this.leftColumn.Name = "leftColumn";
            this.leftColumn.ReadOnly = true;
            this.leftColumn.Width = 64;
            // 
            // rightColumn
            // 
            this.rightColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rightColumn.HeaderText = "Правое";
            this.rightColumn.Name = "rightColumn";
            this.rightColumn.ReadOnly = true;
            this.rightColumn.Width = 70;
            // 
            // vertColumn
            // 
            this.vertColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vertColumn.HeaderText = "Вертикальное";
            this.vertColumn.Name = "vertColumn";
            this.vertColumn.ReadOnly = true;
            this.vertColumn.Width = 104;
            // 
            // textColumn
            // 
            this.textColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.textColumn.HeaderText = "Текст";
            this.textColumn.Name = "textColumn";
            this.textColumn.ReadOnly = true;
            // 
            // panelVideo
            // 
            this.panelVideo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelVideo.Controls.Add(this.vlcControlPanel);
            this.panelVideo.Controls.Add(this.toolBar2);
            this.panelVideo.Controls.Add(this.panel1);
            this.panelVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVideo.Location = new System.Drawing.Point(0, 52);
            this.panelVideo.Name = "panelVideo";
            this.panelVideo.Size = new System.Drawing.Size(461, 343);
            this.panelVideo.TabIndex = 2;
            // 
            // vlcControlPanel
            // 
            this.vlcControlPanel.Controls.Add(this.vlcControl1);
            this.vlcControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vlcControlPanel.Location = new System.Drawing.Point(31, 0);
            this.vlcControlPanel.Name = "vlcControlPanel";
            this.vlcControlPanel.Size = new System.Drawing.Size(426, 253);
            this.vlcControlPanel.TabIndex = 7;
            // 
            // vlcControl1
            // 
            this.vlcControl1.BackColor = System.Drawing.Color.Black;
            this.vlcControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vlcControl1.Location = new System.Drawing.Point(0, 0);
            this.vlcControl1.Name = "vlcControl1";
            this.vlcControl1.Size = new System.Drawing.Size(426, 253);
            this.vlcControl1.Spu = -1;
            this.vlcControl1.TabIndex = 6;
            this.vlcControl1.Text = "vlcControl1";
            this.vlcControl1.VlcLibDirectory = null;
            this.vlcControl1.VlcMediaplayerOptions = null;
            this.vlcControl1.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl_VlcLibDirectoryNeeded);
            // 
            // toolBar2
            // 
            this.toolBar2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolBar2.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.coordToolBarButton,
            this.moveToolBarButton,
            this.rotateToolBarButton});
            this.toolBar2.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolBar2.DropDownArrows = true;
            this.toolBar2.ImageList = this.imageList2;
            this.toolBar2.Location = new System.Drawing.Point(0, 0);
            this.toolBar2.Name = "toolBar2";
            this.toolBar2.ShowToolTips = true;
            this.toolBar2.Size = new System.Drawing.Size(31, 253);
            this.toolBar2.TabIndex = 3;
            this.toolBar2.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar2_ButtonClick);
            // 
            // coordToolBarButton
            // 
            this.coordToolBarButton.ImageIndex = 0;
            this.coordToolBarButton.Name = "coordToolBarButton";
            // 
            // moveToolBarButton
            // 
            this.moveToolBarButton.ImageIndex = 3;
            this.moveToolBarButton.Name = "moveToolBarButton";
            // 
            // rotateToolBarButton
            // 
            this.rotateToolBarButton.ImageIndex = 6;
            this.rotateToolBarButton.Name = "rotateToolBarButton";
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.White;
            this.imageList2.Images.SetKeyName(0, "axis.png");
            this.imageList2.Images.SetKeyName(1, "diskette.png");
            this.imageList2.Images.SetKeyName(2, "document.png");
            this.imageList2.Images.SetKeyName(3, "move.png");
            this.imageList2.Images.SetKeyName(4, "movie-clapper-open.png");
            this.imageList2.Images.SetKeyName(5, "open-file-button.png");
            this.imageList2.Images.SetKeyName(6, "rotation.png");
            this.imageList2.Images.SetKeyName(7, "vertical-line.png");
            this.imageList2.Images.SetKeyName(8, "refresh.png");
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.trackBarPanel);
            this.panel1.Controls.Add(this.statusBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 253);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 86);
            this.panel1.TabIndex = 5;
            // 
            // trackBarPanel
            // 
            this.trackBarPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trackBarPanel.Controls.Add(this.toolBarPanel);
            this.trackBarPanel.Controls.Add(this.trackBar1);
            this.trackBarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarPanel.Location = new System.Drawing.Point(0, 24);
            this.trackBarPanel.Name = "trackBarPanel";
            this.trackBarPanel.Size = new System.Drawing.Size(455, 60);
            this.trackBarPanel.TabIndex = 6;
            // 
            // toolBarPanel
            // 
            this.toolBarPanel.Controls.Add(this.volumeTrackBar);
            this.toolBarPanel.Controls.Add(this.toolBar1);
            this.toolBarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolBarPanel.Location = new System.Drawing.Point(0, 32);
            this.toolBarPanel.Name = "toolBarPanel";
            this.toolBarPanel.Size = new System.Drawing.Size(453, 26);
            this.toolBarPanel.TabIndex = 5;
            // 
            // volumeTrackBar
            // 
            this.volumeTrackBar.AutoSize = false;
            this.volumeTrackBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.volumeTrackBar.Location = new System.Drawing.Point(313, 0);
            this.volumeTrackBar.Maximum = 100;
            this.volumeTrackBar.Name = "volumeTrackBar";
            this.volumeTrackBar.Size = new System.Drawing.Size(140, 26);
            this.volumeTrackBar.SmallChange = 5;
            this.volumeTrackBar.TabIndex = 2;
            this.volumeTrackBar.TickFrequency = 25;
            this.volumeTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeTrackBar.Value = 100;
            this.volumeTrackBar.ValueChanged += new System.EventHandler(this.volumeTrackBar_ValueChanged);
            // 
            // toolBar1
            // 
            this.toolBar1.AutoSize = false;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButton1,
            this.toolBarButton2,
            this.toolBarButton3});
            this.toolBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(453, 30);
            this.toolBar1.TabIndex = 1;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.ImageIndex = 0;
            this.toolBarButton1.Name = "toolBarButton1";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.ImageIndex = 1;
            this.toolBarButton2.Name = "toolBarButton2";
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.ImageIndex = 2;
            this.toolBarButton3.Name = "toolBarButton3";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Red;
            this.imageList1.Images.SetKeyName(0, "Play.bmp");
            this.imageList1.Images.SetKeyName(1, "Pause.bmp");
            this.imageList1.Images.SetKeyName(2, "Stop.bmp");
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackBar1.Location = new System.Drawing.Point(0, 0);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(453, 32);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.MouseCaptureChanged += new System.EventHandler(this.trackBar1_MouseCaptureChanged);
            this.trackBar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseDown);
            this.trackBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseUp);
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusBar1.Location = new System.Drawing.Point(0, 0);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(455, 24);
            this.statusBar1.TabIndex = 2;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel1.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "Ready";
            this.statusBarPanel1.Width = 322;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Text = "00:00:00";
            this.statusBarPanel2.Width = 58;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Text = "00:00:00";
            this.statusBarPanel3.Width = 58;
            // 
            // panelSubChange
            // 
            this.panelSubChange.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSubChange.Controls.Add(this.originalSubTextBox);
            this.panelSubChange.Controls.Add(this.editedSubTextBox);
            this.panelSubChange.Controls.Add(this.editSubFlowLayoutPanel);
            this.panelSubChange.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSubChange.Location = new System.Drawing.Point(461, 52);
            this.panelSubChange.Name = "panelSubChange";
            this.panelSubChange.Size = new System.Drawing.Size(635, 343);
            this.panelSubChange.TabIndex = 2;
            // 
            // originalSubTextBox
            // 
            this.originalSubTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.originalSubTextBox.Location = new System.Drawing.Point(0, 66);
            this.originalSubTextBox.Multiline = true;
            this.originalSubTextBox.Name = "originalSubTextBox";
            this.originalSubTextBox.ReadOnly = true;
            this.originalSubTextBox.Size = new System.Drawing.Size(631, 123);
            this.originalSubTextBox.TabIndex = 1;
            // 
            // editedSubTextBox
            // 
            this.editedSubTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.editedSubTextBox.Location = new System.Drawing.Point(0, 189);
            this.editedSubTextBox.Multiline = true;
            this.editedSubTextBox.Name = "editedSubTextBox";
            this.editedSubTextBox.Size = new System.Drawing.Size(631, 150);
            this.editedSubTextBox.TabIndex = 0;
            this.editedSubTextBox.TextChanged += new System.EventHandler(this.editedSubTextBox_TextChanged);
            // 
            // editSubFlowLayoutPanel
            // 
            this.editSubFlowLayoutPanel.AutoSize = true;
            this.editSubFlowLayoutPanel.Controls.Add(this.stylesPanel);
            this.editSubFlowLayoutPanel.Controls.Add(this.editStylesButtonPanel);
            this.editSubFlowLayoutPanel.Controls.Add(this.actorPanel);
            this.editSubFlowLayoutPanel.Controls.Add(this.effectButton);
            this.editSubFlowLayoutPanel.Controls.Add(this.editEffectButtonPanel);
            this.editSubFlowLayoutPanel.Controls.Add(this.numPanel);
            this.editSubFlowLayoutPanel.Controls.Add(this.marginPanel);
            this.editSubFlowLayoutPanel.Controls.Add(this.timePanel);
            this.editSubFlowLayoutPanel.Controls.Add(this.buttonsPanel);
            this.editSubFlowLayoutPanel.Controls.Add(this.originalPanel);
            this.editSubFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.editSubFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.editSubFlowLayoutPanel.Name = "editSubFlowLayoutPanel";
            this.editSubFlowLayoutPanel.Size = new System.Drawing.Size(631, 66);
            this.editSubFlowLayoutPanel.TabIndex = 38;
            // 
            // stylesPanel
            // 
            this.stylesPanel.AutoSize = true;
            this.stylesPanel.Controls.Add(this.styleComboBox);
            this.stylesPanel.Location = new System.Drawing.Point(3, 3);
            this.stylesPanel.Name = "stylesPanel";
            this.stylesPanel.Size = new System.Drawing.Size(130, 25);
            this.stylesPanel.TabIndex = 31;
            // 
            // styleComboBox
            // 
            this.styleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.styleComboBox.FormattingEnabled = true;
            this.styleComboBox.Location = new System.Drawing.Point(0, 1);
            this.styleComboBox.Name = "styleComboBox";
            this.styleComboBox.Size = new System.Drawing.Size(127, 21);
            this.styleComboBox.TabIndex = 2;
            // 
            // editStylesButtonPanel
            // 
            this.editStylesButtonPanel.AutoSize = true;
            this.editStylesButtonPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editStylesButtonPanel.Controls.Add(this.changeStyleButton);
            this.editStylesButtonPanel.Location = new System.Drawing.Point(139, 3);
            this.editStylesButtonPanel.Name = "editStylesButtonPanel";
            this.editStylesButtonPanel.Size = new System.Drawing.Size(81, 25);
            this.editStylesButtonPanel.TabIndex = 32;
            // 
            // changeStyleButton
            // 
            this.changeStyleButton.AutoSize = true;
            this.changeStyleButton.Location = new System.Drawing.Point(3, -1);
            this.changeStyleButton.Name = "changeStyleButton";
            this.changeStyleButton.Size = new System.Drawing.Size(75, 23);
            this.changeStyleButton.TabIndex = 3;
            this.changeStyleButton.Text = "Изменить";
            this.changeStyleButton.UseVisualStyleBackColor = true;
            this.changeStyleButton.Click += new System.EventHandler(this.changeStyleButton_Click);
            // 
            // actorPanel
            // 
            this.actorPanel.AutoSize = true;
            this.actorPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.actorPanel.Controls.Add(this.actorComboBox);
            this.actorPanel.Location = new System.Drawing.Point(226, 3);
            this.actorPanel.Name = "actorPanel";
            this.actorPanel.Size = new System.Drawing.Size(113, 25);
            this.actorPanel.TabIndex = 33;
            // 
            // actorComboBox
            // 
            this.actorComboBox.FormattingEnabled = true;
            this.actorComboBox.Location = new System.Drawing.Point(3, 1);
            this.actorComboBox.Name = "actorComboBox";
            this.actorComboBox.Size = new System.Drawing.Size(107, 21);
            this.actorComboBox.TabIndex = 4;
            this.actorComboBox.Text = "Актер";
            // 
            // effectButton
            // 
            this.effectButton.AutoSize = true;
            this.effectButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.effectButton.Controls.Add(this.effectComboBox);
            this.effectButton.Location = new System.Drawing.Point(345, 3);
            this.effectButton.Name = "effectButton";
            this.effectButton.Size = new System.Drawing.Size(127, 25);
            this.effectButton.TabIndex = 33;
            // 
            // effectComboBox
            // 
            this.effectComboBox.FormattingEnabled = true;
            this.effectComboBox.Location = new System.Drawing.Point(3, 1);
            this.effectComboBox.Name = "effectComboBox";
            this.effectComboBox.Size = new System.Drawing.Size(121, 21);
            this.effectComboBox.TabIndex = 5;
            this.effectComboBox.Text = "Эффект";
            // 
            // editEffectButtonPanel
            // 
            this.editEffectButtonPanel.AutoSize = true;
            this.editEffectButtonPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editEffectButtonPanel.Controls.Add(this.changeEffectButton);
            this.editEffectButtonPanel.Location = new System.Drawing.Point(478, 3);
            this.editEffectButtonPanel.Name = "editEffectButtonPanel";
            this.editEffectButtonPanel.Size = new System.Drawing.Size(81, 25);
            this.editEffectButtonPanel.TabIndex = 35;
            // 
            // changeEffectButton
            // 
            this.changeEffectButton.Location = new System.Drawing.Point(3, -1);
            this.changeEffectButton.Name = "changeEffectButton";
            this.changeEffectButton.Size = new System.Drawing.Size(75, 23);
            this.changeEffectButton.TabIndex = 6;
            this.changeEffectButton.Text = "Изменить";
            this.changeEffectButton.UseVisualStyleBackColor = true;
            // 
            // numPanel
            // 
            this.numPanel.AutoSize = true;
            this.numPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.numPanel.Controls.Add(this.levelDomainUpDown);
            this.numPanel.Location = new System.Drawing.Point(565, 3);
            this.numPanel.Name = "numPanel";
            this.numPanel.Size = new System.Drawing.Size(41, 25);
            this.numPanel.TabIndex = 36;
            // 
            // levelDomainUpDown
            // 
            this.levelDomainUpDown.Location = new System.Drawing.Point(3, 2);
            this.levelDomainUpDown.Name = "levelDomainUpDown";
            this.levelDomainUpDown.Size = new System.Drawing.Size(35, 20);
            this.levelDomainUpDown.TabIndex = 26;
            // 
            // marginPanel
            // 
            this.marginPanel.AutoSize = true;
            this.marginPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.marginPanel.Controls.Add(this.leftMaskedTextBox);
            this.marginPanel.Controls.Add(this.rightMaskedTextBox);
            this.marginPanel.Controls.Add(this.vertMaskedTextBox);
            this.marginPanel.Location = new System.Drawing.Point(3, 34);
            this.marginPanel.Name = "marginPanel";
            this.marginPanel.Size = new System.Drawing.Size(121, 24);
            this.marginPanel.TabIndex = 36;
            // 
            // leftMaskedTextBox
            // 
            this.leftMaskedTextBox.Location = new System.Drawing.Point(4, 1);
            this.leftMaskedTextBox.Mask = "0000";
            this.leftMaskedTextBox.Name = "leftMaskedTextBox";
            this.leftMaskedTextBox.Size = new System.Drawing.Size(34, 20);
            this.leftMaskedTextBox.TabIndex = 28;
            this.leftMaskedTextBox.ValidatingType = typeof(int);
            // 
            // rightMaskedTextBox
            // 
            this.rightMaskedTextBox.Location = new System.Drawing.Point(44, 1);
            this.rightMaskedTextBox.Mask = "0000";
            this.rightMaskedTextBox.Name = "rightMaskedTextBox";
            this.rightMaskedTextBox.Size = new System.Drawing.Size(34, 20);
            this.rightMaskedTextBox.TabIndex = 30;
            this.rightMaskedTextBox.ValidatingType = typeof(int);
            // 
            // vertMaskedTextBox
            // 
            this.vertMaskedTextBox.Location = new System.Drawing.Point(84, 1);
            this.vertMaskedTextBox.Mask = "0000";
            this.vertMaskedTextBox.Name = "vertMaskedTextBox";
            this.vertMaskedTextBox.Size = new System.Drawing.Size(34, 20);
            this.vertMaskedTextBox.TabIndex = 29;
            this.vertMaskedTextBox.ValidatingType = typeof(int);
            // 
            // timePanel
            // 
            this.timePanel.AutoSize = true;
            this.timePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.timePanel.Controls.Add(this.beginTextBox);
            this.timePanel.Controls.Add(this.endTextBox);
            this.timePanel.Controls.Add(this.durationTextBox);
            this.timePanel.Location = new System.Drawing.Point(130, 34);
            this.timePanel.Name = "timePanel";
            this.timePanel.Size = new System.Drawing.Size(228, 24);
            this.timePanel.TabIndex = 33;
            // 
            // beginTextBox
            // 
            this.beginTextBox.Location = new System.Drawing.Point(3, 1);
            this.beginTextBox.Name = "beginTextBox";
            this.beginTextBox.Size = new System.Drawing.Size(70, 20);
            this.beginTextBox.TabIndex = 7;
            // 
            // endTextBox
            // 
            this.endTextBox.Location = new System.Drawing.Point(79, 1);
            this.endTextBox.Name = "endTextBox";
            this.endTextBox.Size = new System.Drawing.Size(70, 20);
            this.endTextBox.TabIndex = 8;
            // 
            // durationTextBox
            // 
            this.durationTextBox.Location = new System.Drawing.Point(155, 1);
            this.durationTextBox.Name = "durationTextBox";
            this.durationTextBox.Size = new System.Drawing.Size(70, 20);
            this.durationTextBox.TabIndex = 9;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.AutoSize = true;
            this.buttonsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonsPanel.Controls.Add(this.boldButton);
            this.buttonsPanel.Controls.Add(this.cursiveButton);
            this.buttonsPanel.Controls.Add(this.underlineButton);
            this.buttonsPanel.Controls.Add(this.strikeoutButton);
            this.buttonsPanel.Controls.Add(this.fontsizeButton);
            this.buttonsPanel.Location = new System.Drawing.Point(364, 34);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(130, 29);
            this.buttonsPanel.TabIndex = 34;
            // 
            // boldButton
            // 
            this.boldButton.Image = ((System.Drawing.Image)(resources.GetObject("boldButton.Image")));
            this.boldButton.Location = new System.Drawing.Point(3, 1);
            this.boldButton.Name = "boldButton";
            this.boldButton.Size = new System.Drawing.Size(20, 25);
            this.boldButton.TabIndex = 21;
            this.boldButton.UseVisualStyleBackColor = true;
            this.boldButton.Click += new System.EventHandler(this.boldButton_Click);
            // 
            // cursiveButton
            // 
            this.cursiveButton.Image = ((System.Drawing.Image)(resources.GetObject("cursiveButton.Image")));
            this.cursiveButton.Location = new System.Drawing.Point(29, 1);
            this.cursiveButton.Name = "cursiveButton";
            this.cursiveButton.Size = new System.Drawing.Size(20, 25);
            this.cursiveButton.TabIndex = 22;
            this.cursiveButton.UseVisualStyleBackColor = true;
            this.cursiveButton.Click += new System.EventHandler(this.cursiveButton_Click);
            // 
            // underlineButton
            // 
            this.underlineButton.Image = ((System.Drawing.Image)(resources.GetObject("underlineButton.Image")));
            this.underlineButton.Location = new System.Drawing.Point(55, 1);
            this.underlineButton.Name = "underlineButton";
            this.underlineButton.Size = new System.Drawing.Size(20, 25);
            this.underlineButton.TabIndex = 23;
            this.underlineButton.UseVisualStyleBackColor = true;
            this.underlineButton.Click += new System.EventHandler(this.underlineButton_Click);
            // 
            // strikeoutButton
            // 
            this.strikeoutButton.Image = ((System.Drawing.Image)(resources.GetObject("strikeoutButton.Image")));
            this.strikeoutButton.Location = new System.Drawing.Point(81, 1);
            this.strikeoutButton.Name = "strikeoutButton";
            this.strikeoutButton.Size = new System.Drawing.Size(20, 25);
            this.strikeoutButton.TabIndex = 24;
            this.strikeoutButton.UseVisualStyleBackColor = true;
            this.strikeoutButton.Click += new System.EventHandler(this.strikeoutButton_Click);
            // 
            // fontsizeButton
            // 
            this.fontsizeButton.Image = ((System.Drawing.Image)(resources.GetObject("fontsizeButton.Image")));
            this.fontsizeButton.Location = new System.Drawing.Point(107, 1);
            this.fontsizeButton.Name = "fontsizeButton";
            this.fontsizeButton.Size = new System.Drawing.Size(20, 25);
            this.fontsizeButton.TabIndex = 25;
            this.fontsizeButton.UseVisualStyleBackColor = true;
            this.fontsizeButton.Click += new System.EventHandler(this.fontsizeButton_Click);
            // 
            // originalPanel
            // 
            this.originalPanel.AutoSize = true;
            this.originalPanel.Controls.Add(this.originalCheckBox);
            this.originalPanel.Location = new System.Drawing.Point(500, 34);
            this.originalPanel.Name = "originalPanel";
            this.originalPanel.Size = new System.Drawing.Size(81, 23);
            this.originalPanel.TabIndex = 37;
            // 
            // originalCheckBox
            // 
            this.originalCheckBox.AutoSize = true;
            this.originalCheckBox.Location = new System.Drawing.Point(3, 3);
            this.originalCheckBox.Name = "originalCheckBox";
            this.originalCheckBox.Size = new System.Drawing.Size(75, 17);
            this.originalCheckBox.TabIndex = 27;
            this.originalCheckBox.Text = "Оригинал";
            this.originalCheckBox.UseVisualStyleBackColor = true;
            this.originalCheckBox.CheckedChanged += new System.EventHandler(this.originalCheckBox_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolBar3
            // 
            this.toolBar3.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.newSubToolBarButton,
            this.openSubToolBarButton,
            this.saveSubToolBarButton,
            this.openVideoToolBarButton,
            this.refreshToolBarButton});
            this.toolBar3.DropDownArrows = true;
            this.toolBar3.ImageList = this.imageList2;
            this.toolBar3.Location = new System.Drawing.Point(0, 24);
            this.toolBar3.Name = "toolBar3";
            this.toolBar3.ShowToolTips = true;
            this.toolBar3.Size = new System.Drawing.Size(1096, 28);
            this.toolBar3.TabIndex = 3;
            this.toolBar3.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar3_ButtonClick);
            // 
            // newSubToolBarButton
            // 
            this.newSubToolBarButton.ImageIndex = 2;
            this.newSubToolBarButton.Name = "newSubToolBarButton";
            // 
            // openSubToolBarButton
            // 
            this.openSubToolBarButton.ImageIndex = 5;
            this.openSubToolBarButton.Name = "openSubToolBarButton";
            // 
            // saveSubToolBarButton
            // 
            this.saveSubToolBarButton.ImageIndex = 1;
            this.saveSubToolBarButton.Name = "saveSubToolBarButton";
            // 
            // openVideoToolBarButton
            // 
            this.openVideoToolBarButton.ImageIndex = 4;
            this.openVideoToolBarButton.Name = "openVideoToolBarButton";
            // 
            // refreshToolBarButton
            // 
            this.refreshToolBarButton.ImageIndex = 8;
            this.refreshToolBarButton.Name = "refreshToolBarButton";
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 645);
            this.Controls.Add(this.panelVideo);
            this.Controls.Add(this.panelSubChange);
            this.Controls.Add(this.panelTable);
            this.Controls.Add(this.toolBar3);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "SubRed";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.subDataGridView)).EndInit();
            this.panelVideo.ResumeLayout(false);
            this.panelVideo.PerformLayout();
            this.vlcControlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.trackBarPanel.ResumeLayout(false);
            this.toolBarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            this.panelSubChange.ResumeLayout(false);
            this.panelSubChange.PerformLayout();
            this.editSubFlowLayoutPanel.ResumeLayout(false);
            this.editSubFlowLayoutPanel.PerformLayout();
            this.stylesPanel.ResumeLayout(false);
            this.editStylesButtonPanel.ResumeLayout(false);
            this.editStylesButtonPanel.PerformLayout();
            this.actorPanel.ResumeLayout(false);
            this.effectButton.ResumeLayout(false);
            this.editEffectButtonPanel.ResumeLayout(false);
            this.numPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.levelDomainUpDown)).EndInit();
            this.marginPanel.ResumeLayout(false);
            this.marginPanel.PerformLayout();
            this.timePanel.ResumeLayout(false);
            this.timePanel.PerformLayout();
            this.buttonsPanel.ResumeLayout(false);
            this.originalPanel.ResumeLayout(false);
            this.originalPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeVideoToolStripMenuItem;
        private System.Windows.Forms.Panel panelTable;
        private System.Windows.Forms.Panel panelVideo;
        private System.Windows.Forms.Panel panelSubChange;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.Windows.Forms.ToolBarButton toolBarButton3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView subDataGridView;
        private System.Windows.Forms.ToolBar toolBar2;
        private System.Windows.Forms.ToolBar toolBar3;
        private System.Windows.Forms.ToolStripMenuItem subToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox originalSubTextBox;
        private System.Windows.Forms.TextBox editedSubTextBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolBarButton newSubToolBarButton;
        private System.Windows.Forms.ToolBarButton saveSubToolBarButton;
        private System.Windows.Forms.ToolBarButton openVideoToolBarButton;
        private System.Windows.Forms.ToolBarButton openSubToolBarButton;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ToolBarButton coordToolBarButton;
        private System.Windows.Forms.ToolBarButton moveToolBarButton;
        private System.Windows.Forms.ToolBarButton rotateToolBarButton;
        private System.Windows.Forms.ToolStripMenuItem stylesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsSubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelSubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backSubToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cutSubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem putSubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSubToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem findSubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem автоматизацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectCrossedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem putInMSWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortAndRenumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findAndChangeToolStripMenuItem;
        private System.Windows.Forms.Button changeEffectButton;
        private System.Windows.Forms.ComboBox effectComboBox;
        private System.Windows.Forms.ComboBox actorComboBox;
        private System.Windows.Forms.Button changeStyleButton;
        private System.Windows.Forms.ComboBox styleComboBox;
        private System.Windows.Forms.NumericUpDown levelDomainUpDown;
        private System.Windows.Forms.Button fontsizeButton;
        private System.Windows.Forms.Button boldButton;
        private System.Windows.Forms.Button strikeoutButton;
        private System.Windows.Forms.Button cursiveButton;
        private System.Windows.Forms.Button underlineButton;
        private System.Windows.Forms.TextBox durationTextBox;
        private System.Windows.Forms.TextBox endTextBox;
        private System.Windows.Forms.TextBox beginTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripMenuItem effectsToolStripMenuItem;
        private Vlc.DotNet.Forms.VlcControl vlcControl1;
        private System.Windows.Forms.CheckBox originalCheckBox;
        private System.Windows.Forms.MaskedTextBox rightMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox vertMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox leftMaskedTextBox;
        private System.Windows.Forms.Panel trackBarPanel;
        private System.Windows.Forms.Panel toolBarPanel;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoSubOnlyToolStripMenuItem;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Panel timePanel;
        private System.Windows.Forms.Panel editEffectButtonPanel;
        private System.Windows.Forms.Panel effectButton;
        private System.Windows.Forms.Panel actorPanel;
        private System.Windows.Forms.Panel editStylesButtonPanel;
        private System.Windows.Forms.Panel stylesPanel;
        private System.Windows.Forms.Panel marginPanel;
        private System.Windows.Forms.Panel numPanel;
        private System.Windows.Forms.Panel originalPanel;
        private System.Windows.Forms.FlowLayoutPanel editSubFlowLayoutPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn beginColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn styleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn effectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vertColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn textColumn;
        private System.Windows.Forms.TrackBar volumeTrackBar;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripMenuItem сместитьВремяНаToolStripMenuItem;
        private System.Windows.Forms.Panel vlcControlPanel;
        private System.Windows.Forms.ToolBarButton refreshToolBarButton;
    }
}

