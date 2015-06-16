using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Library;

namespace MultiDesktop
{
    public class CalculatorPanel : MainPanel
    {
        private Calculator calculator;
        private Converter converter;
        private TabPage tabPage4;
        private TabPage tabPage3;
        private TabPage tabPage1;
        private GroupBox trigGroupBox;
        private RadioButton radRadioButton;
        private RadioButton degRadioButton;
        private Button coshButton;
        private TextBox inputBox;
        private ListBox consoleBox;
        private TabControl tabControl1;
        private CheckBox arcCheckBox;
        private Button cothButton;
        private Button cschButton;
        private Button sechButton;
        private Button cotButton;
        private Button secButton;
        private Button cscButton;
        private Button tanButton;
        private Button cosButton;
        private Button sinButton;
        private Button tanhButton;
        private Button sinhButton;
        private Label label1;
        private Button piButton;
        private GroupBox sciGroupBox;
        private Button zButton;
        private Button yButton;
        private Button ceButton;
        private Button xButton;
        private Button facButton;
        private Button powButton;
        private Button eButton;
        private Button modButton;
        private Button lnButton;
        private Button logButton;
        private Button rightParButton;
        private Button leftParButton;
        private Button delButton;
        private Button ansButton;
        private GroupBox basicGroupBox;
        private Button divButton;
        private Button negButton;
        private Button cButton;
        private Button sqrtButton;
        private Button equalButton;
        private Button decimalButton;
        private Button zeroButton;
        private Button enterButton;
        private Button threeButton;
        private Button twoButton;
        private Button oneButton;
        private Button plusButton;
        private Button sixButton;
        private Button fiveButton;
        private Button fourButton;
        private Button minusButton;
        private Button nineButton;
        private Button eightButton;
        private Button sevenButton;
        private Button mulButton;

        #region Component Designer variables

        private IContainer components = null;

        #endregion        

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.basicGroupBox = new System.Windows.Forms.GroupBox();
            this.equalButton = new System.Windows.Forms.Button();
            this.decimalButton = new System.Windows.Forms.Button();
            this.zeroButton = new System.Windows.Forms.Button();
            this.enterButton = new System.Windows.Forms.Button();
            this.threeButton = new System.Windows.Forms.Button();
            this.twoButton = new System.Windows.Forms.Button();
            this.oneButton = new System.Windows.Forms.Button();
            this.plusButton = new System.Windows.Forms.Button();
            this.sixButton = new System.Windows.Forms.Button();
            this.fiveButton = new System.Windows.Forms.Button();
            this.fourButton = new System.Windows.Forms.Button();
            this.minusButton = new System.Windows.Forms.Button();
            this.nineButton = new System.Windows.Forms.Button();
            this.eightButton = new System.Windows.Forms.Button();
            this.sevenButton = new System.Windows.Forms.Button();
            this.mulButton = new System.Windows.Forms.Button();
            this.divButton = new System.Windows.Forms.Button();
            this.negButton = new System.Windows.Forms.Button();
            this.cButton = new System.Windows.Forms.Button();
            this.sciGroupBox = new System.Windows.Forms.GroupBox();
            this.sqrtButton = new System.Windows.Forms.Button();
            this.facButton = new System.Windows.Forms.Button();
            this.powButton = new System.Windows.Forms.Button();
            this.eButton = new System.Windows.Forms.Button();
            this.modButton = new System.Windows.Forms.Button();
            this.lnButton = new System.Windows.Forms.Button();
            this.logButton = new System.Windows.Forms.Button();
            this.rightParButton = new System.Windows.Forms.Button();
            this.leftParButton = new System.Windows.Forms.Button();
            this.delButton = new System.Windows.Forms.Button();
            this.ansButton = new System.Windows.Forms.Button();
            this.zButton = new System.Windows.Forms.Button();
            this.yButton = new System.Windows.Forms.Button();
            this.ceButton = new System.Windows.Forms.Button();
            this.xButton = new System.Windows.Forms.Button();
            this.trigGroupBox = new System.Windows.Forms.GroupBox();
            this.piButton = new System.Windows.Forms.Button();
            this.arcCheckBox = new System.Windows.Forms.CheckBox();
            this.cothButton = new System.Windows.Forms.Button();
            this.cschButton = new System.Windows.Forms.Button();
            this.sechButton = new System.Windows.Forms.Button();
            this.cotButton = new System.Windows.Forms.Button();
            this.secButton = new System.Windows.Forms.Button();
            this.cscButton = new System.Windows.Forms.Button();
            this.tanButton = new System.Windows.Forms.Button();
            this.cosButton = new System.Windows.Forms.Button();
            this.sinButton = new System.Windows.Forms.Button();
            this.tanhButton = new System.Windows.Forms.Button();
            this.sinhButton = new System.Windows.Forms.Button();
            this.radRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.degRadioButton = new System.Windows.Forms.RadioButton();
            this.coshButton = new System.Windows.Forms.Button();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.consoleBox = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            this.basicGroupBox.SuspendLayout();
            this.sciGroupBox.SuspendLayout();
            this.trigGroupBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(524, 396);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Plugin";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(524, 396);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Converter";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.basicGroupBox);
            this.tabPage1.Controls.Add(this.sciGroupBox);
            this.tabPage1.Controls.Add(this.trigGroupBox);
            this.tabPage1.Controls.Add(this.inputBox);
            this.tabPage1.Controls.Add(this.consoleBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(524, 396);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Calculator";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // basicGroupBox
            // 
            this.basicGroupBox.Controls.Add(this.equalButton);
            this.basicGroupBox.Controls.Add(this.decimalButton);
            this.basicGroupBox.Controls.Add(this.zeroButton);
            this.basicGroupBox.Controls.Add(this.enterButton);
            this.basicGroupBox.Controls.Add(this.threeButton);
            this.basicGroupBox.Controls.Add(this.twoButton);
            this.basicGroupBox.Controls.Add(this.oneButton);
            this.basicGroupBox.Controls.Add(this.plusButton);
            this.basicGroupBox.Controls.Add(this.sixButton);
            this.basicGroupBox.Controls.Add(this.fiveButton);
            this.basicGroupBox.Controls.Add(this.fourButton);
            this.basicGroupBox.Controls.Add(this.minusButton);
            this.basicGroupBox.Controls.Add(this.nineButton);
            this.basicGroupBox.Controls.Add(this.eightButton);
            this.basicGroupBox.Controls.Add(this.sevenButton);
            this.basicGroupBox.Controls.Add(this.mulButton);
            this.basicGroupBox.Controls.Add(this.divButton);
            this.basicGroupBox.Controls.Add(this.negButton);
            this.basicGroupBox.Controls.Add(this.cButton);
            this.basicGroupBox.Location = new System.Drawing.Point(368, 226);
            this.basicGroupBox.Name = "basicGroupBox";
            this.basicGroupBox.Size = new System.Drawing.Size(150, 164);
            this.basicGroupBox.TabIndex = 5;
            this.basicGroupBox.TabStop = false;
            this.basicGroupBox.Text = "Basic";
            // 
            // equalButton
            // 
            this.equalButton.Location = new System.Drawing.Point(114, 106);
            this.equalButton.Name = "equalButton";
            this.equalButton.Size = new System.Drawing.Size(30, 23);
            this.equalButton.TabIndex = 49;
            this.equalButton.Text = "=";
            this.equalButton.UseVisualStyleBackColor = true;
            this.equalButton.Click += new System.EventHandler(this.equalButton_Click);
            // 
            // decimalButton
            // 
            this.decimalButton.Location = new System.Drawing.Point(42, 135);
            this.decimalButton.Name = "decimalButton";
            this.decimalButton.Size = new System.Drawing.Size(30, 23);
            this.decimalButton.TabIndex = 48;
            this.decimalButton.Text = ".";
            this.decimalButton.UseVisualStyleBackColor = true;
            this.decimalButton.Click += new System.EventHandler(this.decimalButton_Click);
            // 
            // zeroButton
            // 
            this.zeroButton.Location = new System.Drawing.Point(6, 135);
            this.zeroButton.Name = "zeroButton";
            this.zeroButton.Size = new System.Drawing.Size(30, 23);
            this.zeroButton.TabIndex = 47;
            this.zeroButton.Text = "0";
            this.zeroButton.UseVisualStyleBackColor = true;
            this.zeroButton.Click += new System.EventHandler(this.zeroButton_Click);
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(78, 135);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(66, 23);
            this.enterButton.TabIndex = 46;
            this.enterButton.Text = "ENTER";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // threeButton
            // 
            this.threeButton.Location = new System.Drawing.Point(78, 106);
            this.threeButton.Name = "threeButton";
            this.threeButton.Size = new System.Drawing.Size(30, 23);
            this.threeButton.TabIndex = 45;
            this.threeButton.Text = "3";
            this.threeButton.UseVisualStyleBackColor = true;
            this.threeButton.Click += new System.EventHandler(this.threeButton_Click);
            // 
            // twoButton
            // 
            this.twoButton.Location = new System.Drawing.Point(42, 106);
            this.twoButton.Name = "twoButton";
            this.twoButton.Size = new System.Drawing.Size(30, 23);
            this.twoButton.TabIndex = 44;
            this.twoButton.Text = "2";
            this.twoButton.UseVisualStyleBackColor = true;
            this.twoButton.Click += new System.EventHandler(this.twoButton_Click);
            // 
            // oneButton
            // 
            this.oneButton.Location = new System.Drawing.Point(6, 106);
            this.oneButton.Name = "oneButton";
            this.oneButton.Size = new System.Drawing.Size(30, 23);
            this.oneButton.TabIndex = 43;
            this.oneButton.Text = "1";
            this.oneButton.UseVisualStyleBackColor = true;
            this.oneButton.Click += new System.EventHandler(this.oneButton_Click);
            // 
            // plusButton
            // 
            this.plusButton.Location = new System.Drawing.Point(114, 77);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(30, 23);
            this.plusButton.TabIndex = 42;
            this.plusButton.Text = "+";
            this.plusButton.UseVisualStyleBackColor = true;
            this.plusButton.Click += new System.EventHandler(this.plusButton_Click);
            // 
            // sixButton
            // 
            this.sixButton.Location = new System.Drawing.Point(78, 77);
            this.sixButton.Name = "sixButton";
            this.sixButton.Size = new System.Drawing.Size(30, 23);
            this.sixButton.TabIndex = 41;
            this.sixButton.Text = "6";
            this.sixButton.UseVisualStyleBackColor = true;
            this.sixButton.Click += new System.EventHandler(this.sixButton_Click);
            // 
            // fiveButton
            // 
            this.fiveButton.Location = new System.Drawing.Point(42, 77);
            this.fiveButton.Name = "fiveButton";
            this.fiveButton.Size = new System.Drawing.Size(30, 23);
            this.fiveButton.TabIndex = 40;
            this.fiveButton.Text = "5";
            this.fiveButton.UseVisualStyleBackColor = true;
            this.fiveButton.Click += new System.EventHandler(this.fiveButton_Click);
            // 
            // fourButton
            // 
            this.fourButton.Location = new System.Drawing.Point(6, 77);
            this.fourButton.Name = "fourButton";
            this.fourButton.Size = new System.Drawing.Size(30, 23);
            this.fourButton.TabIndex = 39;
            this.fourButton.Text = "4";
            this.fourButton.UseVisualStyleBackColor = true;
            this.fourButton.Click += new System.EventHandler(this.fourButton_Click);
            // 
            // minusButton
            // 
            this.minusButton.Location = new System.Drawing.Point(114, 48);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(30, 23);
            this.minusButton.TabIndex = 38;
            this.minusButton.Text = "−";
            this.minusButton.UseVisualStyleBackColor = true;
            this.minusButton.Click += new System.EventHandler(this.minusButton_Click);
            // 
            // nineButton
            // 
            this.nineButton.Location = new System.Drawing.Point(78, 48);
            this.nineButton.Name = "nineButton";
            this.nineButton.Size = new System.Drawing.Size(30, 23);
            this.nineButton.TabIndex = 37;
            this.nineButton.Text = "9";
            this.nineButton.UseVisualStyleBackColor = true;
            this.nineButton.Click += new System.EventHandler(this.nineButton_Click);
            // 
            // eightButton
            // 
            this.eightButton.Location = new System.Drawing.Point(42, 48);
            this.eightButton.Name = "eightButton";
            this.eightButton.Size = new System.Drawing.Size(30, 23);
            this.eightButton.TabIndex = 36;
            this.eightButton.Text = "8";
            this.eightButton.UseVisualStyleBackColor = true;
            this.eightButton.Click += new System.EventHandler(this.eightButton_Click);
            // 
            // sevenButton
            // 
            this.sevenButton.Location = new System.Drawing.Point(6, 48);
            this.sevenButton.Name = "sevenButton";
            this.sevenButton.Size = new System.Drawing.Size(30, 23);
            this.sevenButton.TabIndex = 35;
            this.sevenButton.Text = "7";
            this.sevenButton.UseVisualStyleBackColor = true;
            this.sevenButton.Click += new System.EventHandler(this.sevenButton_Click);
            // 
            // mulButton
            // 
            this.mulButton.Location = new System.Drawing.Point(114, 19);
            this.mulButton.Name = "mulButton";
            this.mulButton.Size = new System.Drawing.Size(30, 23);
            this.mulButton.TabIndex = 34;
            this.mulButton.Text = "×";
            this.mulButton.UseVisualStyleBackColor = true;
            this.mulButton.Click += new System.EventHandler(this.mulButton_Click);
            // 
            // divButton
            // 
            this.divButton.Location = new System.Drawing.Point(78, 19);
            this.divButton.Name = "divButton";
            this.divButton.Size = new System.Drawing.Size(30, 23);
            this.divButton.TabIndex = 33;
            this.divButton.Text = "÷";
            this.divButton.UseVisualStyleBackColor = true;
            this.divButton.Click += new System.EventHandler(this.divButton_Click);
            // 
            // negButton
            // 
            this.negButton.Location = new System.Drawing.Point(42, 19);
            this.negButton.Name = "negButton";
            this.negButton.Size = new System.Drawing.Size(30, 23);
            this.negButton.TabIndex = 32;
            this.negButton.Text = "±";
            this.negButton.UseVisualStyleBackColor = true;
            this.negButton.Click += new System.EventHandler(this.negButton_Click);
            // 
            // cButton
            // 
            this.cButton.Location = new System.Drawing.Point(6, 19);
            this.cButton.Name = "cButton";
            this.cButton.Size = new System.Drawing.Size(30, 23);
            this.cButton.TabIndex = 31;
            this.cButton.Text = "C";
            this.cButton.UseVisualStyleBackColor = true;
            this.cButton.Click += new System.EventHandler(this.cButton_Click);
            // 
            // sciGroupBox
            // 
            this.sciGroupBox.Controls.Add(this.sqrtButton);
            this.sciGroupBox.Controls.Add(this.facButton);
            this.sciGroupBox.Controls.Add(this.powButton);
            this.sciGroupBox.Controls.Add(this.eButton);
            this.sciGroupBox.Controls.Add(this.modButton);
            this.sciGroupBox.Controls.Add(this.lnButton);
            this.sciGroupBox.Controls.Add(this.logButton);
            this.sciGroupBox.Controls.Add(this.rightParButton);
            this.sciGroupBox.Controls.Add(this.leftParButton);
            this.sciGroupBox.Controls.Add(this.delButton);
            this.sciGroupBox.Controls.Add(this.ansButton);
            this.sciGroupBox.Controls.Add(this.zButton);
            this.sciGroupBox.Controls.Add(this.yButton);
            this.sciGroupBox.Controls.Add(this.ceButton);
            this.sciGroupBox.Controls.Add(this.xButton);
            this.sciGroupBox.Location = new System.Drawing.Point(212, 226);
            this.sciGroupBox.Name = "sciGroupBox";
            this.sciGroupBox.Size = new System.Drawing.Size(150, 164);
            this.sciGroupBox.TabIndex = 4;
            this.sciGroupBox.TabStop = false;
            this.sciGroupBox.Text = "Scientific";
            // 
            // sqrtButton
            // 
            this.sqrtButton.Location = new System.Drawing.Point(6, 135);
            this.sqrtButton.Name = "sqrtButton";
            this.sqrtButton.Size = new System.Drawing.Size(42, 23);
            this.sqrtButton.TabIndex = 30;
            this.sqrtButton.Text = "√¯";
            this.sqrtButton.UseVisualStyleBackColor = true;
            this.sqrtButton.Click += new System.EventHandler(this.sqrtButton_Click);
            // 
            // facButton
            // 
            this.facButton.Location = new System.Drawing.Point(54, 135);
            this.facButton.Name = "facButton";
            this.facButton.Size = new System.Drawing.Size(42, 23);
            this.facButton.TabIndex = 29;
            this.facButton.Text = "n!";
            this.facButton.UseVisualStyleBackColor = true;
            this.facButton.Click += new System.EventHandler(this.facButton_Click);
            // 
            // powButton
            // 
            this.powButton.Location = new System.Drawing.Point(6, 106);
            this.powButton.Name = "powButton";
            this.powButton.Size = new System.Drawing.Size(42, 23);
            this.powButton.TabIndex = 28;
            this.powButton.Text = "^";
            this.powButton.UseVisualStyleBackColor = true;
            this.powButton.Click += new System.EventHandler(this.powButton_Click);
            // 
            // eButton
            // 
            this.eButton.Location = new System.Drawing.Point(54, 106);
            this.eButton.Name = "eButton";
            this.eButton.Size = new System.Drawing.Size(42, 23);
            this.eButton.TabIndex = 27;
            this.eButton.Text = "e";
            this.eButton.UseVisualStyleBackColor = true;
            this.eButton.Click += new System.EventHandler(this.eButton_Click);
            // 
            // modButton
            // 
            this.modButton.Location = new System.Drawing.Point(102, 135);
            this.modButton.Name = "modButton";
            this.modButton.Size = new System.Drawing.Size(42, 23);
            this.modButton.TabIndex = 26;
            this.modButton.Text = "MOD";
            this.modButton.UseVisualStyleBackColor = true;
            this.modButton.Click += new System.EventHandler(this.modButton_Click);
            // 
            // lnButton
            // 
            this.lnButton.Location = new System.Drawing.Point(102, 106);
            this.lnButton.Name = "lnButton";
            this.lnButton.Size = new System.Drawing.Size(42, 23);
            this.lnButton.TabIndex = 26;
            this.lnButton.Text = "ln";
            this.lnButton.UseVisualStyleBackColor = true;
            this.lnButton.Click += new System.EventHandler(this.lnButton_Click);
            // 
            // logButton
            // 
            this.logButton.Location = new System.Drawing.Point(102, 77);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(42, 23);
            this.logButton.TabIndex = 25;
            this.logButton.Text = "log";
            this.logButton.UseVisualStyleBackColor = true;
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // rightParButton
            // 
            this.rightParButton.Location = new System.Drawing.Point(54, 77);
            this.rightParButton.Name = "rightParButton";
            this.rightParButton.Size = new System.Drawing.Size(42, 23);
            this.rightParButton.TabIndex = 24;
            this.rightParButton.Text = ")";
            this.rightParButton.UseVisualStyleBackColor = true;
            this.rightParButton.Click += new System.EventHandler(this.rightParButton_Click);
            // 
            // leftParButton
            // 
            this.leftParButton.Location = new System.Drawing.Point(6, 77);
            this.leftParButton.Name = "leftParButton";
            this.leftParButton.Size = new System.Drawing.Size(42, 23);
            this.leftParButton.TabIndex = 23;
            this.leftParButton.Text = "(";
            this.leftParButton.UseVisualStyleBackColor = true;
            this.leftParButton.Click += new System.EventHandler(this.leftParButton_Click);
            // 
            // delButton
            // 
            this.delButton.Location = new System.Drawing.Point(102, 48);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(42, 23);
            this.delButton.TabIndex = 22;
            this.delButton.Text = "DEL";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // ansButton
            // 
            this.ansButton.Location = new System.Drawing.Point(54, 48);
            this.ansButton.Name = "ansButton";
            this.ansButton.Size = new System.Drawing.Size(42, 23);
            this.ansButton.TabIndex = 21;
            this.ansButton.Text = "ANS";
            this.ansButton.UseVisualStyleBackColor = true;
            this.ansButton.Click += new System.EventHandler(this.ansButton_Click);
            // 
            // zButton
            // 
            this.zButton.Location = new System.Drawing.Point(102, 19);
            this.zButton.Name = "zButton";
            this.zButton.Size = new System.Drawing.Size(42, 23);
            this.zButton.TabIndex = 20;
            this.zButton.Text = "z-var";
            this.zButton.UseVisualStyleBackColor = true;
            this.zButton.Click += new System.EventHandler(this.zButton_Click);
            // 
            // yButton
            // 
            this.yButton.Location = new System.Drawing.Point(54, 19);
            this.yButton.Name = "yButton";
            this.yButton.Size = new System.Drawing.Size(42, 23);
            this.yButton.TabIndex = 19;
            this.yButton.Text = "y-var";
            this.yButton.UseVisualStyleBackColor = true;
            this.yButton.Click += new System.EventHandler(this.yButton_Click);
            // 
            // ceButton
            // 
            this.ceButton.Location = new System.Drawing.Point(6, 48);
            this.ceButton.Name = "ceButton";
            this.ceButton.Size = new System.Drawing.Size(42, 23);
            this.ceButton.TabIndex = 17;
            this.ceButton.Text = "CE";
            this.ceButton.UseVisualStyleBackColor = true;
            this.ceButton.Click += new System.EventHandler(this.ceButton_Click);
            // 
            // xButton
            // 
            this.xButton.Location = new System.Drawing.Point(6, 19);
            this.xButton.Name = "xButton";
            this.xButton.Size = new System.Drawing.Size(42, 23);
            this.xButton.TabIndex = 18;
            this.xButton.Text = "x-var";
            this.xButton.UseVisualStyleBackColor = true;
            this.xButton.Click += new System.EventHandler(this.xButton_Click);
            // 
            // trigGroupBox
            // 
            this.trigGroupBox.Controls.Add(this.piButton);
            this.trigGroupBox.Controls.Add(this.arcCheckBox);
            this.trigGroupBox.Controls.Add(this.cothButton);
            this.trigGroupBox.Controls.Add(this.cschButton);
            this.trigGroupBox.Controls.Add(this.sechButton);
            this.trigGroupBox.Controls.Add(this.cotButton);
            this.trigGroupBox.Controls.Add(this.secButton);
            this.trigGroupBox.Controls.Add(this.cscButton);
            this.trigGroupBox.Controls.Add(this.tanButton);
            this.trigGroupBox.Controls.Add(this.cosButton);
            this.trigGroupBox.Controls.Add(this.sinButton);
            this.trigGroupBox.Controls.Add(this.tanhButton);
            this.trigGroupBox.Controls.Add(this.sinhButton);
            this.trigGroupBox.Controls.Add(this.radRadioButton);
            this.trigGroupBox.Controls.Add(this.label1);
            this.trigGroupBox.Controls.Add(this.degRadioButton);
            this.trigGroupBox.Controls.Add(this.coshButton);
            this.trigGroupBox.Location = new System.Drawing.Point(6, 226);
            this.trigGroupBox.Name = "trigGroupBox";
            this.trigGroupBox.Size = new System.Drawing.Size(200, 164);
            this.trigGroupBox.TabIndex = 3;
            this.trigGroupBox.TabStop = false;
            this.trigGroupBox.Text = "Trigonometry";
            // 
            // piButton
            // 
            this.piButton.Location = new System.Drawing.Point(25, 48);
            this.piButton.Name = "piButton";
            this.piButton.Size = new System.Drawing.Size(25, 23);
            this.piButton.TabIndex = 16;
            this.piButton.Text = "π";
            this.piButton.UseVisualStyleBackColor = true;
            this.piButton.Click += new System.EventHandler(this.piButton_Click);
            // 
            // arcCheckBox
            // 
            this.arcCheckBox.AutoSize = true;
            this.arcCheckBox.Location = new System.Drawing.Point(9, 94);
            this.arcCheckBox.Name = "arcCheckBox";
            this.arcCheckBox.Size = new System.Drawing.Size(41, 17);
            this.arcCheckBox.TabIndex = 15;
            this.arcCheckBox.Text = "arc";
            this.arcCheckBox.UseVisualStyleBackColor = true;
            // 
            // cothButton
            // 
            this.cothButton.Location = new System.Drawing.Point(152, 135);
            this.cothButton.Name = "cothButton";
            this.cothButton.Size = new System.Drawing.Size(42, 23);
            this.cothButton.TabIndex = 13;
            this.cothButton.Text = "coth";
            this.cothButton.UseVisualStyleBackColor = true;
            this.cothButton.Click += new System.EventHandler(this.cothButton_Click);
            // 
            // cschButton
            // 
            this.cschButton.Location = new System.Drawing.Point(56, 135);
            this.cschButton.Name = "cschButton";
            this.cschButton.Size = new System.Drawing.Size(42, 23);
            this.cschButton.TabIndex = 14;
            this.cschButton.Text = "csch";
            this.cschButton.UseVisualStyleBackColor = true;
            this.cschButton.Click += new System.EventHandler(this.cschButton_Click);
            // 
            // sechButton
            // 
            this.sechButton.Location = new System.Drawing.Point(104, 135);
            this.sechButton.Name = "sechButton";
            this.sechButton.Size = new System.Drawing.Size(42, 23);
            this.sechButton.TabIndex = 12;
            this.sechButton.Text = "sech";
            this.sechButton.UseVisualStyleBackColor = true;
            this.sechButton.Click += new System.EventHandler(this.sechButton_Click);
            // 
            // cotButton
            // 
            this.cotButton.Location = new System.Drawing.Point(152, 77);
            this.cotButton.Name = "cotButton";
            this.cotButton.Size = new System.Drawing.Size(42, 23);
            this.cotButton.TabIndex = 11;
            this.cotButton.Text = "cot";
            this.cotButton.UseVisualStyleBackColor = true;
            this.cotButton.Click += new System.EventHandler(this.cotButton_Click);
            // 
            // secButton
            // 
            this.secButton.Location = new System.Drawing.Point(104, 77);
            this.secButton.Name = "secButton";
            this.secButton.Size = new System.Drawing.Size(42, 23);
            this.secButton.TabIndex = 10;
            this.secButton.Text = "sec";
            this.secButton.UseVisualStyleBackColor = true;
            this.secButton.Click += new System.EventHandler(this.secButton_Click);
            // 
            // cscButton
            // 
            this.cscButton.Location = new System.Drawing.Point(56, 77);
            this.cscButton.Name = "cscButton";
            this.cscButton.Size = new System.Drawing.Size(42, 23);
            this.cscButton.TabIndex = 9;
            this.cscButton.Text = "csc";
            this.cscButton.UseVisualStyleBackColor = true;
            this.cscButton.Click += new System.EventHandler(this.cscButton_Click);
            // 
            // tanButton
            // 
            this.tanButton.Location = new System.Drawing.Point(152, 48);
            this.tanButton.Name = "tanButton";
            this.tanButton.Size = new System.Drawing.Size(42, 23);
            this.tanButton.TabIndex = 8;
            this.tanButton.Text = "tan";
            this.tanButton.UseVisualStyleBackColor = true;
            this.tanButton.Click += new System.EventHandler(this.tanButton_Click);
            // 
            // cosButton
            // 
            this.cosButton.Location = new System.Drawing.Point(104, 48);
            this.cosButton.Name = "cosButton";
            this.cosButton.Size = new System.Drawing.Size(42, 23);
            this.cosButton.TabIndex = 7;
            this.cosButton.Text = "cos";
            this.cosButton.UseVisualStyleBackColor = true;
            this.cosButton.Click += new System.EventHandler(this.cosButton_Click);
            // 
            // sinButton
            // 
            this.sinButton.Location = new System.Drawing.Point(56, 48);
            this.sinButton.Name = "sinButton";
            this.sinButton.Size = new System.Drawing.Size(42, 23);
            this.sinButton.TabIndex = 6;
            this.sinButton.Text = "sin";
            this.sinButton.UseVisualStyleBackColor = true;
            this.sinButton.Click += new System.EventHandler(this.sinButton_Click);
            // 
            // tanhButton
            // 
            this.tanhButton.Location = new System.Drawing.Point(152, 106);
            this.tanhButton.Name = "tanhButton";
            this.tanhButton.Size = new System.Drawing.Size(42, 23);
            this.tanhButton.TabIndex = 4;
            this.tanhButton.Text = "tanh";
            this.tanhButton.UseVisualStyleBackColor = true;
            this.tanhButton.Click += new System.EventHandler(this.tanhButton_Click);
            // 
            // sinhButton
            // 
            this.sinhButton.Location = new System.Drawing.Point(56, 106);
            this.sinhButton.Name = "sinhButton";
            this.sinhButton.Size = new System.Drawing.Size(42, 23);
            this.sinhButton.TabIndex = 5;
            this.sinhButton.Text = "sinh";
            this.sinhButton.UseVisualStyleBackColor = true;
            this.sinhButton.Click += new System.EventHandler(this.sinhButton_Click);
            // 
            // radRadioButton
            // 
            this.radRadioButton.AutoSize = true;
            this.radRadioButton.Checked = true;
            this.radRadioButton.Location = new System.Drawing.Point(130, 14);
            this.radRadioButton.Name = "radRadioButton";
            this.radRadioButton.Size = new System.Drawing.Size(64, 17);
            this.radRadioButton.TabIndex = 1;
            this.radRadioButton.TabStop = true;
            this.radRadioButton.Text = "Radians";
            this.radRadioButton.UseVisualStyleBackColor = true;
            this.radRadioButton.CheckedChanged += new System.EventHandler(this.radRadioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mode";
            // 
            // degRadioButton
            // 
            this.degRadioButton.AutoSize = true;
            this.degRadioButton.Location = new System.Drawing.Point(60, 14);
            this.degRadioButton.Name = "degRadioButton";
            this.degRadioButton.Size = new System.Drawing.Size(65, 17);
            this.degRadioButton.TabIndex = 0;
            this.degRadioButton.Text = "Degrees";
            this.degRadioButton.UseVisualStyleBackColor = true;
            this.degRadioButton.CheckedChanged += new System.EventHandler(this.degRadioButton_CheckedChanged);
            // 
            // coshButton
            // 
            this.coshButton.Location = new System.Drawing.Point(104, 106);
            this.coshButton.Name = "coshButton";
            this.coshButton.Size = new System.Drawing.Size(42, 23);
            this.coshButton.TabIndex = 2;
            this.coshButton.Text = "cosh";
            this.coshButton.UseVisualStyleBackColor = true;
            this.coshButton.Click += new System.EventHandler(this.coshButton_Click);
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(6, 200);
            this.inputBox.Name = "inputBox";
            this.inputBox.TextAlign = HorizontalAlignment.Right;
            this.inputBox.Size = new System.Drawing.Size(512, 20);
            this.inputBox.TabIndex = 1;
            // 
            // consoleBox
            // 
            this.consoleBox.FormattingEnabled = true;
            this.consoleBox.Location = new System.Drawing.Point(6, 6);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.Size = new System.Drawing.Size(512, 186);
            this.consoleBox.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(532, 422);
            this.tabControl1.TabIndex = 1;
            // 
            // CalculatorPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(556, 446);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalculatorPanel";
            this.ShowInTaskbar = false;
            this.Text = "Calculator Panel";
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.basicGroupBox.ResumeLayout(false);
            this.sciGroupBox.ResumeLayout(false);
            this.trigGroupBox.ResumeLayout(false);
            this.trigGroupBox.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public CalculatorPanel() : base("Calculator")
        {
            InitializeComponent();
            calculator = new Calculator();
        }

        private void degRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            calculator.setDegrees();
        }

        private void radRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            calculator.setRadians();
        }

        private void piButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, "π");
            inputBox.SelectionStart = pos + 1;
            inputBox.Update();
        }

        private void sinButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            if (arcCheckBox.Checked)
            {
                inputBox.Text = inputBox.Text.Insert(pos, "arcsin ");
                inputBox.SelectionStart = pos + 7;
            }
            else
            {
                inputBox.Text = inputBox.Text.Insert(pos, "sin ");
                inputBox.SelectionStart = pos + 4;
            }
            inputBox.Update();
        }

        private void cosButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            if (arcCheckBox.Checked)
            {
                inputBox.Text = inputBox.Text.Insert(pos, "arccos ");
                inputBox.SelectionStart = pos + 7;
            }
            else
            {
                inputBox.Text = inputBox.Text.Insert(pos, "cos ");
                inputBox.SelectionStart = pos + 4;
            }
            inputBox.Update();
        }

        private void tanButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            if (arcCheckBox.Checked)
            {
                inputBox.Text = inputBox.Text.Insert(pos, "arctan ");
                inputBox.SelectionStart = pos + 7;
            }
            else
            {
                inputBox.Text = inputBox.Text.Insert(pos, "tan ");
                inputBox.SelectionStart = pos + 4;
            }
            inputBox.Update();
        }

        private void cscButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            if (arcCheckBox.Checked)
            {
                inputBox.Text = inputBox.Text.Insert(pos, "arccsc ");
                inputBox.SelectionStart = pos + 7;
            }
            else
            {
                inputBox.Text = inputBox.Text.Insert(pos, "csc ");
                inputBox.SelectionStart = pos + 4;
            }
            inputBox.Update();
        }

        private void secButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            if (arcCheckBox.Checked)
            {
                inputBox.Text = inputBox.Text.Insert(pos, "arcsec ");
                inputBox.SelectionStart = pos + 7;
            }
            else
            {
                inputBox.Text = inputBox.Text.Insert(pos, "sec ");
                inputBox.SelectionStart = pos + 4;
            }
            inputBox.Update();
        }

        private void cotButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            if (arcCheckBox.Checked)
            {
                inputBox.Text = inputBox.Text.Insert(pos, "arccot ");
                inputBox.SelectionStart = pos + 7;
            }
            else
            {
                inputBox.Text = inputBox.Text.Insert(pos, "cot ");
                inputBox.SelectionStart = pos + 4;
            }
            inputBox.Update();
        }

        private void sinhButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            if (arcCheckBox.Checked)
            {
                inputBox.Text = inputBox.Text.Insert(pos, "arcsinh ");
                inputBox.SelectionStart = pos + 8;
            }
            else
            {
                inputBox.Text = inputBox.Text.Insert(pos, "sinh ");
                inputBox.SelectionStart = pos + 5;
            }
            inputBox.Update();
        }

        private void coshButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            if (arcCheckBox.Checked)
            {
                inputBox.Text = inputBox.Text.Insert(pos, "arccosh ");
                inputBox.SelectionStart = pos + 8;
            }
            else
            {
                inputBox.Text = inputBox.Text.Insert(pos, "cosh ");
                inputBox.SelectionStart = pos + 5;
            }
            inputBox.Update();
        }

        private void tanhButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            if (arcCheckBox.Checked)
            {
                inputBox.Text = inputBox.Text.Insert(pos, "arctanh ");
                inputBox.SelectionStart = pos + 8;
            }
            else
            {
                inputBox.Text = inputBox.Text.Insert(pos, "tanh ");
                inputBox.SelectionStart = pos + 5;
            }
            inputBox.Update();
        }

        private void cschButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            if (arcCheckBox.Checked)
            {
                inputBox.Text = inputBox.Text.Insert(pos, "arccsch ");
                inputBox.SelectionStart = pos + 8;
            }
            else
            {
                inputBox.Text = inputBox.Text.Insert(pos, "csch ");
                inputBox.SelectionStart = pos + 5;
            }
            inputBox.Update();
        }

        private void sechButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            if (arcCheckBox.Checked)
            {
                inputBox.Text = inputBox.Text.Insert(pos, "arcsech ");
                inputBox.SelectionStart = pos + 8;
            }
            else
            {
                inputBox.Text = inputBox.Text.Insert(pos, "sech ");
                inputBox.SelectionStart = pos + 5;
            }
            inputBox.Update();
        }

        private void cothButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            if (arcCheckBox.Checked)
            {
                inputBox.Text = inputBox.Text.Insert(pos, "arccoth ");
                inputBox.SelectionStart = pos + 8;
            }
            else
            {
                inputBox.Text = inputBox.Text.Insert(pos, "coth ");
                inputBox.SelectionStart = pos + 5;
            }
            inputBox.Update();
        }

        private void xButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, "x");
            inputBox.SelectionStart = pos + 1;
            inputBox.Update();
        }

        private void yButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, "y");
            inputBox.SelectionStart = pos + 1;
            inputBox.Update();
        }

        private void zButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, "z");
            inputBox.SelectionStart = pos + 1;
            inputBox.Update();
        }

        private void ceButton_Click(object sender, EventArgs e)
        {
            consoleBox.Items.Clear();
            inputBox.Text = "";
        }

        private void ansButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, "ans");
            inputBox.SelectionStart = pos + 3;
            inputBox.Update();
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            if (pos < inputBox.Text.Length)
            {
                inputBox.Text = inputBox.Text.Remove(pos, 1);
                inputBox.SelectionStart = pos;
            }
            inputBox.Update();
        }

        private void leftParButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, "(");
            inputBox.SelectionStart = pos + 1;
            inputBox.Update();
        }

        private void rightParButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, ")");
            inputBox.SelectionStart = pos + 1;
            inputBox.Update();
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, "log ");
            inputBox.SelectionStart = pos + 4;
            inputBox.Update();
        }

        private void powButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, " ^ ");
            inputBox.SelectionStart = pos + 3;
            inputBox.Update();
        }

        private void eButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, "e");
            inputBox.SelectionStart = pos + 1;
            inputBox.Update();
        }

        private void lnButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, "ln ");
            inputBox.SelectionStart = pos + 3;
            inputBox.Update();
        }

        private void sqrtButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            if (pos < inputBox.Text.Length - 1)
            {
                inputBox.Text = inputBox.Text.Insert(pos, "√(");
                inputBox.Text = inputBox.Text.Insert(inputBox.Text.Length - 1, ")");
                inputBox.SelectionStart = inputBox.Text.Length - 1;
            }
            else
            {
                inputBox.Text = inputBox.Text.Insert(pos, "√()");
                inputBox.SelectionStart = pos + 2;
            }
            inputBox.Update();
        }

        private void facButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, "!");
            inputBox.SelectionStart = pos + 1;
            inputBox.Update();
        }

        private void modButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, " % ");
            inputBox.SelectionStart = pos + 3;
            inputBox.Update();
        }

        private void cButton_Click(object sender, EventArgs e)
        {
            inputBox.Text = "";
        }

        private void negButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, "-");
            inputBox.SelectionStart = pos + 1;
            inputBox.Update();
        }

        private void divButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, " / ");
            inputBox.SelectionStart = pos + 3;
            inputBox.Update();
        }

        private void mulButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, " * ");
            inputBox.SelectionStart = pos + 3;
            inputBox.Update();
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, "7");
            inputBox.SelectionStart = pos + 1;
            inputBox.Update();
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, "8");
            inputBox.SelectionStart = pos + 1;
            inputBox.Update();
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, "9");
            inputBox.SelectionStart = pos + 1;
            inputBox.Update();
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, " − ");
            inputBox.SelectionStart = pos + 3;
            inputBox.Update();
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, "4");
            inputBox.SelectionStart = pos + 1;
            inputBox.Update();
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, "5");
            inputBox.SelectionStart = pos + 1;
            inputBox.Update();
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, "6");
            inputBox.SelectionStart = pos + 1;
            inputBox.Update();
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, " + ");
            inputBox.SelectionStart = pos + 3;
            inputBox.Update();
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, "1");
            inputBox.SelectionStart = pos + 1;
            inputBox.Update();
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, "2");
            inputBox.SelectionStart = pos + 1;
            inputBox.Update();
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, "3");
            inputBox.SelectionStart = pos + 1;
            inputBox.Update();
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, " = ");
            inputBox.SelectionStart = pos + 3;
            inputBox.Update();
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, "0");
            inputBox.SelectionStart = pos + 1;
            inputBox.Update();
        }

        private void decimalButton_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            int pos = inputBox.SelectionStart;
            inputBox.Text = inputBox.Text.Insert(pos, ".");
            inputBox.SelectionStart = pos + 1;
            inputBox.Update();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            try
            {
                double ans = calculator.compute(inputBox.Text);
                consoleBox.Items.Add(inputBox.Text);
                consoleBox.Items.Add(ans);
                inputBox.Text = "";
            }
            catch(ArgumentException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
