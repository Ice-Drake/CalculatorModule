using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Library;
using PluginSDK;

namespace MultiDesktop
{
    public class CalculatorPanel : MainPanel
    {
        private Calculator calculator;
        private Converter converter;
        private SharedData sharedData;
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
        private GroupBox groupBox1;
        private Button retrieveA1Button;
        private TextBox angleBox2;
        private Label label2;
        private ComboBox angleComboBox1;
        private TextBox angleBox1;
        private GroupBox groupBox6;
        private Button storeW2Button;
        private Button retrieveW2Button;
        private Button storeW1Button;
        private Button retrieveW1Button;
        private TextBox weightBox2;
        private Label label7;
        private ComboBox weightComboBox1;
        private TextBox weightBox1;
        private GroupBox groupBox5;
        private Button storeV2Button;
        private Button retrieveV2Button;
        private Button storeV1Button;
        private Button retrieveV1Button;
        private TextBox volumeBox2;
        private Label label6;
        private ComboBox volumeComboBox1;
        private TextBox volumeBox1;
        private GroupBox groupBox4;
        private Button storeT2Button;
        private Button retrieveT2Button;
        private Button storeT1Button;
        private Button retrieveT1Button;
        private TextBox tempBox2;
        private Label label5;
        private ComboBox tempComboBox1;
        private TextBox tempBox1;
        private GroupBox groupBox3;
        private Button storeL2Button;
        private Button retrieveL2Button;
        private Button storeL1Button;
        private Button retrieveL1Button;
        private TextBox lengthBox2;
        private Label label4;
        private ComboBox lengthComboBox1;
        private TextBox lengthBox1;
        private GroupBox groupBox2;
        private Button storeA4Button;
        private Button retrieveA4Button;
        private Button storeA3Button;
        private Button retrieveButtonA3;
        private TextBox areaBox2;
        private Label label3;
        private ComboBox areaComboBox1;
        private TextBox areaBox1;
        private Button storeA2Button;
        private Button retrieveA2Button;
        private Button storeA1Button;
        private ComboBox angleComboBox2;
        private ComboBox weightComboBox2;
        private ComboBox volumeComboBox2;
        private ComboBox tempComboBox2;
        private ComboBox lengthComboBox2;
        private ComboBox areaComboBox2;

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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.weightComboBox2 = new System.Windows.Forms.ComboBox();
            this.storeW2Button = new System.Windows.Forms.Button();
            this.retrieveW2Button = new System.Windows.Forms.Button();
            this.storeW1Button = new System.Windows.Forms.Button();
            this.retrieveW1Button = new System.Windows.Forms.Button();
            this.weightBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.weightComboBox1 = new System.Windows.Forms.ComboBox();
            this.weightBox1 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.volumeComboBox2 = new System.Windows.Forms.ComboBox();
            this.storeV2Button = new System.Windows.Forms.Button();
            this.retrieveV2Button = new System.Windows.Forms.Button();
            this.storeV1Button = new System.Windows.Forms.Button();
            this.retrieveV1Button = new System.Windows.Forms.Button();
            this.volumeBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.volumeComboBox1 = new System.Windows.Forms.ComboBox();
            this.volumeBox1 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tempComboBox2 = new System.Windows.Forms.ComboBox();
            this.storeT2Button = new System.Windows.Forms.Button();
            this.retrieveT2Button = new System.Windows.Forms.Button();
            this.storeT1Button = new System.Windows.Forms.Button();
            this.retrieveT1Button = new System.Windows.Forms.Button();
            this.tempBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tempComboBox1 = new System.Windows.Forms.ComboBox();
            this.tempBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lengthComboBox2 = new System.Windows.Forms.ComboBox();
            this.storeL2Button = new System.Windows.Forms.Button();
            this.retrieveL2Button = new System.Windows.Forms.Button();
            this.storeL1Button = new System.Windows.Forms.Button();
            this.retrieveL1Button = new System.Windows.Forms.Button();
            this.lengthBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lengthComboBox1 = new System.Windows.Forms.ComboBox();
            this.lengthBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.areaComboBox2 = new System.Windows.Forms.ComboBox();
            this.storeA4Button = new System.Windows.Forms.Button();
            this.retrieveA4Button = new System.Windows.Forms.Button();
            this.storeA3Button = new System.Windows.Forms.Button();
            this.retrieveButtonA3 = new System.Windows.Forms.Button();
            this.areaBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.areaComboBox1 = new System.Windows.Forms.ComboBox();
            this.areaBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.angleComboBox2 = new System.Windows.Forms.ComboBox();
            this.storeA2Button = new System.Windows.Forms.Button();
            this.retrieveA2Button = new System.Windows.Forms.Button();
            this.storeA1Button = new System.Windows.Forms.Button();
            this.retrieveA1Button = new System.Windows.Forms.Button();
            this.angleBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.angleComboBox1 = new System.Windows.Forms.ComboBox();
            this.angleBox1 = new System.Windows.Forms.TextBox();
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
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.tabPage4.Size = new System.Drawing.Size(524, 486);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Plugin";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(524, 486);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Converter";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.weightComboBox2);
            this.groupBox6.Controls.Add(this.storeW2Button);
            this.groupBox6.Controls.Add(this.retrieveW2Button);
            this.groupBox6.Controls.Add(this.storeW1Button);
            this.groupBox6.Controls.Add(this.retrieveW1Button);
            this.groupBox6.Controls.Add(this.weightBox2);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.weightComboBox1);
            this.groupBox6.Controls.Add(this.weightBox1);
            this.groupBox6.Location = new System.Drawing.Point(6, 406);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(512, 74);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Weight";
            // 
            // weightComboBox2
            // 
            this.weightComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.weightComboBox2.FormattingEnabled = true;
            this.weightComboBox2.Items.AddRange(new object[] {
            "Carat",
            "Centigram",
            "Decigram",
            "Dekagram",
            "Gram",
            "Hectogram",
            "Kilogram",
            "Long Ton",
            "Milligram",
            "Ounce",
            "Pound",
            "Short Ton",
            "Stone",
            "Tonne"});
            this.weightComboBox2.Location = new System.Drawing.Point(375, 19);
            this.weightComboBox2.Name = "weightComboBox2";
            this.weightComboBox2.Size = new System.Drawing.Size(131, 21);
            this.weightComboBox2.TabIndex = 9;
            this.weightComboBox2.SelectedIndex = 10;
            this.weightComboBox2.SelectedIndexChanged += new System.EventHandler(this.weightComboBox2_SelectedIndexChanged);
            // 
            // storeW2Button
            // 
            this.storeW2Button.Location = new System.Drawing.Point(269, 45);
            this.storeW2Button.Name = "storeW2Button";
            this.storeW2Button.Size = new System.Drawing.Size(44, 23);
            this.storeW2Button.TabIndex = 8;
            this.storeW2Button.Text = "→W2";
            this.storeW2Button.UseVisualStyleBackColor = true;
            this.storeW2Button.Click += new System.EventHandler(this.storeW2Button_Click);
            // 
            // retrieveW2Button
            // 
            this.retrieveW2Button.Location = new System.Drawing.Point(325, 45);
            this.retrieveW2Button.Name = "retrieveW2Button";
            this.retrieveW2Button.Size = new System.Drawing.Size(44, 23);
            this.retrieveW2Button.TabIndex = 7;
            this.retrieveW2Button.Text = "←W2";
            this.retrieveW2Button.UseVisualStyleBackColor = true;
            this.retrieveW2Button.Click += new System.EventHandler(this.retrieveW2Button_Click);
            // 
            // storeW1Button
            // 
            this.storeW1Button.Location = new System.Drawing.Point(6, 45);
            this.storeW1Button.Name = "storeW1Button";
            this.storeW1Button.Size = new System.Drawing.Size(44, 23);
            this.storeW1Button.TabIndex = 6;
            this.storeW1Button.Text = "→W1";
            this.storeW1Button.UseVisualStyleBackColor = true;
            this.storeW1Button.Click += new System.EventHandler(this.storeW1Button_Click);
            // 
            // retrieveW1Button
            // 
            this.retrieveW1Button.Location = new System.Drawing.Point(62, 45);
            this.retrieveW1Button.Name = "retrieveW1Button";
            this.retrieveW1Button.Size = new System.Drawing.Size(44, 23);
            this.retrieveW1Button.TabIndex = 5;
            this.retrieveW1Button.Text = "←W1";
            this.retrieveW1Button.UseVisualStyleBackColor = true;
            this.retrieveW1Button.Click += new System.EventHandler(this.retrieveW1Button_Click);
            // 
            // weightBox2
            // 
            this.weightBox2.Location = new System.Drawing.Point(269, 19);
            this.weightBox2.Name = "weightBox2";
            this.weightBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.weightBox2.Size = new System.Drawing.Size(100, 20);
            this.weightBox2.TabIndex = 3;
            this.weightBox2.Text = "1";
            this.weightBox2.TextChanged += new System.EventHandler(this.weightBox2_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(249, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "=";
            // 
            // weightComboBox1
            // 
            this.weightComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.weightComboBox1.FormattingEnabled = true;
            this.weightComboBox1.Items.AddRange(new object[] {
            "Carat",
            "Centigram",
            "Decigram",
            "Dekagram",
            "Gram",
            "Hectogram",
            "Kilogram",
            "Long Ton",
            "Milligram",
            "Ounce",
            "Pound",
            "Short Ton",
            "Stone",
            "Tonne"});
            this.weightComboBox1.Location = new System.Drawing.Point(112, 19);
            this.weightComboBox1.Name = "weightComboBox1";
            this.weightComboBox1.Size = new System.Drawing.Size(131, 21);
            this.weightComboBox1.TabIndex = 1;
            this.weightComboBox1.SelectedIndex = 10;
            this.weightComboBox1.SelectedIndexChanged += new System.EventHandler(this.weightComboBox1_SelectedIndexChanged);
            // 
            // weightBox1
            // 
            this.weightBox1.Location = new System.Drawing.Point(6, 19);
            this.weightBox1.Name = "weightBox1";
            this.weightBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.weightBox1.Size = new System.Drawing.Size(100, 20);
            this.weightBox1.TabIndex = 0;
            this.weightBox1.Text = "1";
            this.weightBox1.TextChanged += new System.EventHandler(this.weightBox1_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.volumeComboBox2);
            this.groupBox5.Controls.Add(this.storeV2Button);
            this.groupBox5.Controls.Add(this.retrieveV2Button);
            this.groupBox5.Controls.Add(this.storeV1Button);
            this.groupBox5.Controls.Add(this.retrieveV1Button);
            this.groupBox5.Controls.Add(this.volumeBox2);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.volumeComboBox1);
            this.groupBox5.Controls.Add(this.volumeBox1);
            this.groupBox5.Location = new System.Drawing.Point(6, 326);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(512, 74);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Volume";
            // 
            // volumeComboBox2
            // 
            this.volumeComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.volumeComboBox2.FormattingEnabled = true;
            this.volumeComboBox2.Items.AddRange(new object[] {
            "Cubic Centimeter",
            "Cubic Feet",
            "Cubic Inch",
            "Cubic Meter",
            "Cubic Yard",
            "Fluid Ounce (UK)",
            "Fluid Ounce (US)",
            "Gallon (UK)",
            "Gallon (US)",
            "Liter",
            "Pint (UK)",
            "Pint (US)",
            "Quart (UK)",
            "Quart (US)"});
            this.volumeComboBox2.Location = new System.Drawing.Point(375, 19);
            this.volumeComboBox2.Name = "volumeComboBox2";
            this.volumeComboBox2.Size = new System.Drawing.Size(131, 21);
            this.volumeComboBox2.TabIndex = 9;
            this.volumeComboBox2.SelectedIndex = 8;
            this.volumeComboBox2.SelectedIndexChanged += new System.EventHandler(this.volumeComboBox2_SelectedIndexChanged);
            // 
            // storeV2Button
            // 
            this.storeV2Button.Location = new System.Drawing.Point(269, 45);
            this.storeV2Button.Name = "storeV2Button";
            this.storeV2Button.Size = new System.Drawing.Size(44, 23);
            this.storeV2Button.TabIndex = 8;
            this.storeV2Button.Text = "→V2";
            this.storeV2Button.UseVisualStyleBackColor = true;
            this.storeV2Button.Click += new System.EventHandler(this.storeV2Button_Click);
            // 
            // retrieveV2Button
            // 
            this.retrieveV2Button.Location = new System.Drawing.Point(325, 45);
            this.retrieveV2Button.Name = "retrieveV2Button";
            this.retrieveV2Button.Size = new System.Drawing.Size(44, 23);
            this.retrieveV2Button.TabIndex = 7;
            this.retrieveV2Button.Text = "←V2";
            this.retrieveV2Button.UseVisualStyleBackColor = true;
            this.retrieveV2Button.Click += new System.EventHandler(this.retrieveV2Button_Click);
            // 
            // storeV1Button
            // 
            this.storeV1Button.Location = new System.Drawing.Point(6, 45);
            this.storeV1Button.Name = "storeV1Button";
            this.storeV1Button.Size = new System.Drawing.Size(44, 23);
            this.storeV1Button.TabIndex = 6;
            this.storeV1Button.Text = "→V1";
            this.storeV1Button.UseVisualStyleBackColor = true;
            this.storeV1Button.Click += new System.EventHandler(this.storeV1Button_Click);
            // 
            // retrieveV1Button
            // 
            this.retrieveV1Button.Location = new System.Drawing.Point(62, 45);
            this.retrieveV1Button.Name = "retrieveV1Button";
            this.retrieveV1Button.Size = new System.Drawing.Size(44, 23);
            this.retrieveV1Button.TabIndex = 5;
            this.retrieveV1Button.Text = "←V1";
            this.retrieveV1Button.UseVisualStyleBackColor = true;
            this.retrieveV1Button.Click += new System.EventHandler(this.retrieveV1Button_Click);
            // 
            // volumeBox2
            // 
            this.volumeBox2.Location = new System.Drawing.Point(269, 19);
            this.volumeBox2.Name = "volumeBox2";
            this.volumeBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.volumeBox2.Size = new System.Drawing.Size(100, 20);
            this.volumeBox2.TabIndex = 3;
            this.volumeBox2.Text = "1";
            this.volumeBox2.TextChanged += new System.EventHandler(this.volumeBox2_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "=";
            // 
            // volumeComboBox1
            // 
            this.volumeComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.volumeComboBox1.FormattingEnabled = true;
            this.volumeComboBox1.Items.AddRange(new object[] {
            "Cubic Centimeter",
            "Cubic Feet",
            "Cubic Inch",
            "Cubic Meter",
            "Cubic Yard",
            "Fluid Ounce (UK)",
            "Fluid Ounce (US)",
            "Gallon (UK)",
            "Gallon (US)",
            "Liter",
            "Pint (UK)",
            "Pint (US)",
            "Quart (UK)",
            "Quart (US)"});
            this.volumeComboBox1.Location = new System.Drawing.Point(112, 19);
            this.volumeComboBox1.Name = "volumeComboBox1";
            this.volumeComboBox1.Size = new System.Drawing.Size(131, 21);
            this.volumeComboBox1.TabIndex = 1;
            this.volumeComboBox1.SelectedIndex = 8;
            this.volumeComboBox1.SelectedIndexChanged += new System.EventHandler(this.volumeComboBox1_SelectedIndexChanged);
            // 
            // volumeBox1
            // 
            this.volumeBox1.Location = new System.Drawing.Point(6, 19);
            this.volumeBox1.Name = "volumeBox1";
            this.volumeBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.volumeBox1.Size = new System.Drawing.Size(100, 20);
            this.volumeBox1.TabIndex = 0;
            this.volumeBox1.Text = "1";
            this.volumeBox1.TextChanged += new System.EventHandler(this.volumeBox1_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tempComboBox2);
            this.groupBox4.Controls.Add(this.storeT2Button);
            this.groupBox4.Controls.Add(this.retrieveT2Button);
            this.groupBox4.Controls.Add(this.storeT1Button);
            this.groupBox4.Controls.Add(this.retrieveT1Button);
            this.groupBox4.Controls.Add(this.tempBox2);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.tempComboBox1);
            this.groupBox4.Controls.Add(this.tempBox1);
            this.groupBox4.Location = new System.Drawing.Point(6, 246);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(512, 74);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Temperature";
            // 
            // tempComboBox2
            // 
            this.tempComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tempComboBox2.FormattingEnabled = true;
            this.tempComboBox2.Items.AddRange(new object[] {
            "°C",
            "°F",
            "°K"});
            this.tempComboBox2.Location = new System.Drawing.Point(375, 19);
            this.tempComboBox2.Name = "tempComboBox2";
            this.tempComboBox2.Size = new System.Drawing.Size(131, 21);
            this.tempComboBox2.TabIndex = 9;
            this.tempComboBox2.SelectedIndex = 0;
            this.tempComboBox2.SelectedIndexChanged += new System.EventHandler(this.tempComboBox2_SelectedIndexChanged);
            // 
            // storeT2Button
            // 
            this.storeT2Button.Location = new System.Drawing.Point(269, 45);
            this.storeT2Button.Name = "storeT2Button";
            this.storeT2Button.Size = new System.Drawing.Size(44, 23);
            this.storeT2Button.TabIndex = 8;
            this.storeT2Button.Text = "→T2";
            this.storeT2Button.UseVisualStyleBackColor = true;
            this.storeT2Button.Click += new System.EventHandler(this.storeT2Button_Click);
            // 
            // retrieveT2Button
            // 
            this.retrieveT2Button.Location = new System.Drawing.Point(325, 45);
            this.retrieveT2Button.Name = "retrieveT2Button";
            this.retrieveT2Button.Size = new System.Drawing.Size(44, 23);
            this.retrieveT2Button.TabIndex = 7;
            this.retrieveT2Button.Text = "←T2";
            this.retrieveT2Button.UseVisualStyleBackColor = true;
            this.retrieveT2Button.Click += new System.EventHandler(this.retrieveT2Button_Click);
            // 
            // storeT1Button
            // 
            this.storeT1Button.Location = new System.Drawing.Point(6, 45);
            this.storeT1Button.Name = "storeT1Button";
            this.storeT1Button.Size = new System.Drawing.Size(44, 23);
            this.storeT1Button.TabIndex = 6;
            this.storeT1Button.Text = "→T1";
            this.storeT1Button.UseVisualStyleBackColor = true;
            this.storeT1Button.Click += new System.EventHandler(this.storeT1Button_Click);
            // 
            // retrieveT1Button
            // 
            this.retrieveT1Button.Location = new System.Drawing.Point(62, 45);
            this.retrieveT1Button.Name = "retrieveT1Button";
            this.retrieveT1Button.Size = new System.Drawing.Size(44, 23);
            this.retrieveT1Button.TabIndex = 5;
            this.retrieveT1Button.Text = "←T1";
            this.retrieveT1Button.UseVisualStyleBackColor = true;
            this.retrieveT1Button.Click += new System.EventHandler(this.retrieveT1Button_Click);
            // 
            // tempBox2
            // 
            this.tempBox2.Location = new System.Drawing.Point(269, 19);
            this.tempBox2.Name = "tempBox2";
            this.tempBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tempBox2.Size = new System.Drawing.Size(100, 20);
            this.tempBox2.TabIndex = 3;
            this.tempBox2.Text = "1";
            this.tempBox2.TextChanged += new System.EventHandler(this.tempBox2_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(249, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "=";
            // 
            // tempComboBox1
            // 
            this.tempComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tempComboBox1.FormattingEnabled = true;
            this.tempComboBox1.Items.AddRange(new object[] {
            "°C",
            "°F",
            "°K"});
            this.tempComboBox1.Location = new System.Drawing.Point(112, 19);
            this.tempComboBox1.Name = "tempComboBox1";
            this.tempComboBox1.Size = new System.Drawing.Size(131, 21);
            this.tempComboBox1.TabIndex = 1;
            this.tempComboBox1.SelectedIndex = 0;
            this.tempComboBox1.SelectedIndexChanged += new System.EventHandler(this.tempComboBox1_SelectedIndexChanged);
            // 
            // tempBox1
            // 
            this.tempBox1.Location = new System.Drawing.Point(6, 19);
            this.tempBox1.Name = "tempBox1";
            this.tempBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tempBox1.Size = new System.Drawing.Size(100, 20);
            this.tempBox1.TabIndex = 0;
            this.tempBox1.Text = "1";
            this.tempBox1.TextChanged += new System.EventHandler(this.tempBox1_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lengthComboBox2);
            this.groupBox3.Controls.Add(this.storeL2Button);
            this.groupBox3.Controls.Add(this.retrieveL2Button);
            this.groupBox3.Controls.Add(this.storeL1Button);
            this.groupBox3.Controls.Add(this.retrieveL1Button);
            this.groupBox3.Controls.Add(this.lengthBox2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.lengthComboBox1);
            this.groupBox3.Controls.Add(this.lengthBox1);
            this.groupBox3.Location = new System.Drawing.Point(6, 166);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(512, 74);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Length";
            // 
            // lengthComboBox2
            // 
            this.lengthComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lengthComboBox2.FormattingEnabled = true;
            this.lengthComboBox2.Items.AddRange(new object[] {
            "Angstrom",
            "Centimeters",
            "Chain",
            "Fathom",
            "Feet",
            "Hand",
            "Inch",
            "Kilometers",
            "Link",
            "Meter",
            "Microns",
            "Mile",
            "Millimeters",
            "Nanometer",
            "Nautical Miles",
            "PICA",
            "Rods",
            "Span",
            "Yard"});
            this.lengthComboBox2.Location = new System.Drawing.Point(375, 19);
            this.lengthComboBox2.Name = "lengthComboBox2";
            this.lengthComboBox2.Size = new System.Drawing.Size(131, 21);
            this.lengthComboBox2.TabIndex = 9;
            this.lengthComboBox2.SelectedIndex = 6;
            this.lengthComboBox2.SelectedIndexChanged += new System.EventHandler(this.lengthComboBox2_SelectedIndexChanged);
            // 
            // storeL2Button
            // 
            this.storeL2Button.Location = new System.Drawing.Point(269, 45);
            this.storeL2Button.Name = "storeL2Button";
            this.storeL2Button.Size = new System.Drawing.Size(44, 23);
            this.storeL2Button.TabIndex = 8;
            this.storeL2Button.Text = "→L2";
            this.storeL2Button.UseVisualStyleBackColor = true;
            this.storeL2Button.Click += new System.EventHandler(this.storeL2Button_Click);
            // 
            // retrieveL2Button
            // 
            this.retrieveL2Button.Location = new System.Drawing.Point(325, 45);
            this.retrieveL2Button.Name = "retrieveL2Button";
            this.retrieveL2Button.Size = new System.Drawing.Size(44, 23);
            this.retrieveL2Button.TabIndex = 7;
            this.retrieveL2Button.Text = "←L2";
            this.retrieveL2Button.UseVisualStyleBackColor = true;
            this.retrieveL2Button.Click += new System.EventHandler(this.retrieveL2Button_Click);
            // 
            // storeL1Button
            // 
            this.storeL1Button.Location = new System.Drawing.Point(6, 45);
            this.storeL1Button.Name = "storeL1Button";
            this.storeL1Button.Size = new System.Drawing.Size(44, 23);
            this.storeL1Button.TabIndex = 6;
            this.storeL1Button.Text = "→L1";
            this.storeL1Button.UseVisualStyleBackColor = true;
            this.storeL1Button.Click += new System.EventHandler(this.storeL1Button_Click);
            // 
            // retrieveL1Button
            // 
            this.retrieveL1Button.Location = new System.Drawing.Point(62, 45);
            this.retrieveL1Button.Name = "retrieveL1Button";
            this.retrieveL1Button.Size = new System.Drawing.Size(44, 23);
            this.retrieveL1Button.TabIndex = 5;
            this.retrieveL1Button.Text = "←L1";
            this.retrieveL1Button.UseVisualStyleBackColor = true;
            this.retrieveL1Button.Click += new System.EventHandler(this.retrieveL1Button_Click);
            // 
            // lengthBox2
            // 
            this.lengthBox2.Location = new System.Drawing.Point(269, 19);
            this.lengthBox2.Name = "lengthBox2";
            this.lengthBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lengthBox2.Size = new System.Drawing.Size(100, 20);
            this.lengthBox2.TabIndex = 3;
            this.lengthBox2.Text = "1";
            this.lengthBox2.TextChanged += new System.EventHandler(this.lengthBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "=";
            // 
            // lengthComboBox1
            // 
            this.lengthComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lengthComboBox1.FormattingEnabled = true;
            this.lengthComboBox1.Items.AddRange(new object[] {
            "Angstrom",
            "Centimeters",
            "Chain",
            "Fathom",
            "Feet",
            "Hand",
            "Inch",
            "Kilometers",
            "Link",
            "Meter",
            "Microns",
            "Mile",
            "Millimeters",
            "Nanometer",
            "Nautical Miles",
            "PICA",
            "Rods",
            "Span",
            "Yard"});
            this.lengthComboBox1.Location = new System.Drawing.Point(112, 19);
            this.lengthComboBox1.Name = "lengthComboBox1";
            this.lengthComboBox1.Size = new System.Drawing.Size(131, 21);
            this.lengthComboBox1.TabIndex = 1;
            this.lengthComboBox1.SelectedIndex = 6;
            this.lengthComboBox1.SelectedIndexChanged += new System.EventHandler(this.lengthComboBox1_SelectedIndexChanged);
            // 
            // lengthBox1
            // 
            this.lengthBox1.Location = new System.Drawing.Point(6, 19);
            this.lengthBox1.Name = "lengthBox1";
            this.lengthBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lengthBox1.Size = new System.Drawing.Size(100, 20);
            this.lengthBox1.TabIndex = 0;
            this.lengthBox1.Text = "1";
            this.lengthBox1.TextChanged += new System.EventHandler(this.lengthBox1_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.areaComboBox2);
            this.groupBox2.Controls.Add(this.storeA4Button);
            this.groupBox2.Controls.Add(this.retrieveA4Button);
            this.groupBox2.Controls.Add(this.storeA3Button);
            this.groupBox2.Controls.Add(this.retrieveButtonA3);
            this.groupBox2.Controls.Add(this.areaBox2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.areaComboBox1);
            this.groupBox2.Controls.Add(this.areaBox1);
            this.groupBox2.Location = new System.Drawing.Point(6, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 74);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Area";
            // 
            // areaComboBox2
            // 
            this.areaComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.areaComboBox2.FormattingEnabled = true;
            this.areaComboBox2.Items.AddRange(new object[] {
            "Acres",
            "Hectares",
            "Square Centimeter",
            "Square Feet",
            "Square Inch",
            "Square Kilometer",
            "Square Meters",
            "Square Mile",
            "Square Millimeter",
            "Square Yard"});
            this.areaComboBox2.Location = new System.Drawing.Point(375, 19);
            this.areaComboBox2.Name = "areaComboBox2";
            this.areaComboBox2.Size = new System.Drawing.Size(131, 21);
            this.areaComboBox2.TabIndex = 9;
            this.areaComboBox2.SelectedIndex = 4;
            this.areaComboBox2.SelectedIndexChanged += new System.EventHandler(this.areaComboBox2_SelectedIndexChanged);
            // 
            // storeA4Button
            // 
            this.storeA4Button.Location = new System.Drawing.Point(269, 45);
            this.storeA4Button.Name = "storeA4Button";
            this.storeA4Button.Size = new System.Drawing.Size(44, 23);
            this.storeA4Button.TabIndex = 8;
            this.storeA4Button.Text = "→A4";
            this.storeA4Button.UseVisualStyleBackColor = true;
            this.storeA4Button.Click += new System.EventHandler(this.storeA4Button_Click);
            // 
            // retrieveA4Button
            // 
            this.retrieveA4Button.Location = new System.Drawing.Point(325, 45);
            this.retrieveA4Button.Name = "retrieveA4Button";
            this.retrieveA4Button.Size = new System.Drawing.Size(44, 23);
            this.retrieveA4Button.TabIndex = 7;
            this.retrieveA4Button.Text = "←A4";
            this.retrieveA4Button.UseVisualStyleBackColor = true;
            this.retrieveA4Button.Click += new System.EventHandler(this.retrieveA4Button_Click);
            // 
            // storeA3Button
            // 
            this.storeA3Button.Location = new System.Drawing.Point(6, 45);
            this.storeA3Button.Name = "storeA3Button";
            this.storeA3Button.Size = new System.Drawing.Size(44, 23);
            this.storeA3Button.TabIndex = 6;
            this.storeA3Button.Text = "→A3";
            this.storeA3Button.UseVisualStyleBackColor = true;
            this.storeA3Button.Click += new System.EventHandler(this.storeA3Button_Click);
            // 
            // retrieveButtonA3
            // 
            this.retrieveButtonA3.Location = new System.Drawing.Point(62, 45);
            this.retrieveButtonA3.Name = "retrieveButtonA3";
            this.retrieveButtonA3.Size = new System.Drawing.Size(44, 23);
            this.retrieveButtonA3.TabIndex = 5;
            this.retrieveButtonA3.Text = "←A3";
            this.retrieveButtonA3.UseVisualStyleBackColor = true;
            this.retrieveButtonA3.Click += new System.EventHandler(this.retrieveButtonA3_Click);
            // 
            // areaBox2
            // 
            this.areaBox2.Location = new System.Drawing.Point(269, 19);
            this.areaBox2.Name = "areaBox2";
            this.areaBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.areaBox2.Size = new System.Drawing.Size(100, 20);
            this.areaBox2.TabIndex = 3;
            this.areaBox2.Text = "1";
            this.areaBox2.TextChanged += new System.EventHandler(this.areaBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "=";
            // 
            // areaComboBox1
            // 
            this.areaComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.areaComboBox1.FormattingEnabled = true;
            this.areaComboBox1.Items.AddRange(new object[] {
            "Acres",
            "Hectares",
            "Square Centimeter",
            "Square Feet",
            "Square Inch",
            "Square Kilometer",
            "Square Meters",
            "Square Mile",
            "Square Millimeter",
            "Square Yard"});
            this.areaComboBox1.Location = new System.Drawing.Point(112, 19);
            this.areaComboBox1.Name = "areaComboBox1";
            this.areaComboBox1.Size = new System.Drawing.Size(131, 21);
            this.areaComboBox1.TabIndex = 1;
            this.areaComboBox1.SelectedIndex = 4;
            this.areaComboBox1.SelectedIndexChanged += new System.EventHandler(this.areaComboBox1_SelectedIndexChanged);
            // 
            // areaBox1
            // 
            this.areaBox1.Location = new System.Drawing.Point(6, 19);
            this.areaBox1.Name = "areaBox1";
            this.areaBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.areaBox1.Size = new System.Drawing.Size(100, 20);
            this.areaBox1.TabIndex = 0;
            this.areaBox1.Text = "1";
            this.areaBox1.TextChanged += new System.EventHandler(this.areaBox1_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.angleComboBox2);
            this.groupBox1.Controls.Add(this.storeA2Button);
            this.groupBox1.Controls.Add(this.retrieveA2Button);
            this.groupBox1.Controls.Add(this.storeA1Button);
            this.groupBox1.Controls.Add(this.retrieveA1Button);
            this.groupBox1.Controls.Add(this.angleBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.angleComboBox1);
            this.groupBox1.Controls.Add(this.angleBox1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Angle";
            // 
            // angleComboBox2
            // 
            this.angleComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.angleComboBox2.FormattingEnabled = true;
            this.angleComboBox2.Items.AddRange(new object[] {
            "Degree",
            "Gradian",
            "Radian"});
            this.angleComboBox2.Location = new System.Drawing.Point(375, 19);
            this.angleComboBox2.Name = "angleComboBox2";
            this.angleComboBox2.Size = new System.Drawing.Size(131, 21);
            this.angleComboBox2.TabIndex = 9;
            this.angleComboBox2.SelectedIndex = 0;
            this.angleComboBox2.SelectedIndexChanged += new System.EventHandler(this.angleComboBox2_SelectedIndexChanged);
            // 
            // storeA2Button
            // 
            this.storeA2Button.Location = new System.Drawing.Point(269, 45);
            this.storeA2Button.Name = "storeA2Button";
            this.storeA2Button.Size = new System.Drawing.Size(44, 23);
            this.storeA2Button.TabIndex = 8;
            this.storeA2Button.Text = "→A2";
            this.storeA2Button.UseVisualStyleBackColor = true;
            this.storeA2Button.Click += new System.EventHandler(this.storeA2Button_Click);
            // 
            // retrieveA2Button
            // 
            this.retrieveA2Button.Location = new System.Drawing.Point(325, 45);
            this.retrieveA2Button.Name = "retrieveA2Button";
            this.retrieveA2Button.Size = new System.Drawing.Size(44, 23);
            this.retrieveA2Button.TabIndex = 7;
            this.retrieveA2Button.Text = "←A2";
            this.retrieveA2Button.UseVisualStyleBackColor = true;
            this.retrieveA2Button.Click += new System.EventHandler(this.retrieveA2Button_Click);
            // 
            // storeA1Button
            // 
            this.storeA1Button.Location = new System.Drawing.Point(6, 45);
            this.storeA1Button.Name = "storeA1Button";
            this.storeA1Button.Size = new System.Drawing.Size(44, 23);
            this.storeA1Button.TabIndex = 6;
            this.storeA1Button.Text = "→A1";
            this.storeA1Button.UseVisualStyleBackColor = true;
            this.storeA1Button.Click += new System.EventHandler(this.storeA1Button_Click);
            // 
            // retrieveA1Button
            // 
            this.retrieveA1Button.Location = new System.Drawing.Point(62, 45);
            this.retrieveA1Button.Name = "retrieveA1Button";
            this.retrieveA1Button.Size = new System.Drawing.Size(44, 23);
            this.retrieveA1Button.TabIndex = 5;
            this.retrieveA1Button.Text = "←A1";
            this.retrieveA1Button.UseVisualStyleBackColor = true;
            this.retrieveA1Button.Click += new System.EventHandler(this.retrieveA1Button_Click);
            // 
            // angleBox2
            // 
            this.angleBox2.Location = new System.Drawing.Point(269, 19);
            this.angleBox2.Name = "angleBox2";
            this.angleBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.angleBox2.Size = new System.Drawing.Size(100, 20);
            this.angleBox2.TabIndex = 3;
            this.angleBox2.Text = "1";
            this.angleBox2.TextChanged += new System.EventHandler(this.angleBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "=";
            // 
            // angleComboBox1
            // 
            this.angleComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.angleComboBox1.FormattingEnabled = true;
            this.angleComboBox1.Items.AddRange(new object[] {
            "Degree",
            "Gradian",
            "Radian"});
            this.angleComboBox1.Location = new System.Drawing.Point(112, 19);
            this.angleComboBox1.Name = "angleComboBox1";
            this.angleComboBox1.Size = new System.Drawing.Size(131, 21);
            this.angleComboBox1.TabIndex = 1;
            this.angleComboBox1.SelectedIndex = 0;
            this.angleComboBox1.SelectedIndexChanged += new System.EventHandler(this.angleComboBox1_SelectedIndexChanged);
            // 
            // angleBox1
            // 
            this.angleBox1.Location = new System.Drawing.Point(6, 19);
            this.angleBox1.Name = "angleBox1";
            this.angleBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.angleBox1.Size = new System.Drawing.Size(100, 20);
            this.angleBox1.TabIndex = 0;
            this.angleBox1.Text = "1";
            this.angleBox1.TextChanged += new System.EventHandler(this.angleBox1_TextChanged);
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
            this.tabPage1.Size = new System.Drawing.Size(524, 486);
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
            this.basicGroupBox.Location = new System.Drawing.Point(368, 316);
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
            this.sciGroupBox.Location = new System.Drawing.Point(212, 316);
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
            this.trigGroupBox.Location = new System.Drawing.Point(6, 316);
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
            this.inputBox.Location = new System.Drawing.Point(6, 8);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(512, 20);
            this.inputBox.TabIndex = 1;
            this.inputBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputBox_KeyDown);
            this.inputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputBox_KeyPress);
            // 
            // consoleBox
            // 
            this.consoleBox.FormattingEnabled = true;
            this.consoleBox.Location = new System.Drawing.Point(6, 34);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.Size = new System.Drawing.Size(512, 277);
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
            this.tabControl1.Size = new System.Drawing.Size(532, 512);
            this.tabControl1.TabIndex = 1;
            // 
            // CalculatorPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(556, 536);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalculatorPanel";
            this.ShowInTaskbar = false;
            this.Text = "Calculator Panel";
            this.tabPage3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
            converter = new Converter();
            sharedData = new SharedData();
        }

        private void compute()
        {
            try
            {
                double ans = calculator.compute(inputBox.Text);
                consoleBox.Items.Insert(0, inputBox.Text);
                consoleBox.Items.Insert(1, "\t\t\t\t\t\t\t\t       " + ans);
                inputBox.Text = "";
            }
            catch (ArithmeticException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void inputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                SendKeys.Send("−");
            }
        }

        private void inputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                compute();
            }
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
                inputBox.Text = inputBox.Text.Insert(pos, "arsinh ");
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
                inputBox.Text = inputBox.Text.Insert(pos, "arcosh ");
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
                inputBox.Text = inputBox.Text.Insert(pos, "artanh ");
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
                inputBox.Text = inputBox.Text.Insert(pos, "arcsch ");
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
                inputBox.Text = inputBox.Text.Insert(pos, "arsech ");
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
                inputBox.Text = inputBox.Text.Insert(pos, "arcoth ");
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
            compute();
        }

        private void angleBox1_TextChanged(object sender, EventArgs e)
        {
            if (angleBox1.Focused && angleBox1.Text.Length > 0)
            {
                try
                {
                    double value = Double.Parse(angleBox1.Text);
                    double answer = converter.convertAngle(angleComboBox1.SelectedIndex, angleComboBox2.SelectedIndex, value);
                    angleBox2.Text = answer.ToString();
                }
                catch(FormatException)
                {
                    MessageBox.Show("You entered an invalid value.");
                }
                catch(OverflowException)
                {
                    MessageBox.Show("The value you entered is way too big to be handled properly.");
                }
            }
        }

        private void angleBox2_TextChanged(object sender, EventArgs e)
        {
            if (angleBox2.Focused && angleBox2.Text.Length > 0)
            {
                try
                {
                    double value = Double.Parse(angleBox2.Text);
                    double answer = converter.convertAngle(angleComboBox2.SelectedIndex, angleComboBox1.SelectedIndex, value);
                    angleBox1.Text = answer.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("You entered an invalid value.");
                }
                catch (OverflowException)
                {
                    MessageBox.Show("The value you entered is way too big to be handled properly.");
                }
            }
        }

        private void areaBox1_TextChanged(object sender, EventArgs e)
        {
            if (areaBox1.Focused && areaBox1.Text.Length > 0)
            {
                try
                {
                    double value = Double.Parse(areaBox1.Text);
                    double answer = converter.convertArea(areaComboBox1.SelectedIndex, areaComboBox2.SelectedIndex, value);
                    areaBox2.Text = answer.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("You entered an invalid value.");
                }
                catch (OverflowException)
                {
                    MessageBox.Show("The value you entered is way too big to be handled properly.");
                }
            }
        }

        private void areaBox2_TextChanged(object sender, EventArgs e)
        {
            if (areaBox2.Focused && areaBox2.Text.Length > 0)
            {
                try
                {
                    double value = Double.Parse(areaBox2.Text);
                    double answer = converter.convertArea(areaComboBox2.SelectedIndex, areaComboBox1.SelectedIndex, value);
                    areaBox1.Text = answer.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("You entered an invalid value.");
                }
                catch (OverflowException)
                {
                    MessageBox.Show("The value you entered is way too big to be handled properly.");
                }
            }
        }

        private void lengthBox1_TextChanged(object sender, EventArgs e)
        {
            if (lengthBox1.Focused && lengthBox1.Text.Length > 0)
            {
                try
                {
                    double value = Double.Parse(lengthBox1.Text);
                    double answer = converter.convertLength(lengthComboBox1.SelectedIndex, lengthComboBox2.SelectedIndex, value);
                    lengthBox2.Text = answer.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("You entered an invalid value.");
                }
                catch (OverflowException)
                {
                    MessageBox.Show("The value you entered is way too big to be handled properly.");
                }
            }
        }

        private void lengthBox2_TextChanged(object sender, EventArgs e)
        {
            if (lengthBox2.Focused && lengthBox2.Text.Length > 0)
            {
                try
                {
                    double value = Double.Parse(lengthBox2.Text);
                    double answer = converter.convertLength(lengthComboBox2.SelectedIndex, lengthComboBox1.SelectedIndex, value);
                    lengthBox1.Text = answer.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("You entered an invalid value.");
                }
                catch (OverflowException)
                {
                    MessageBox.Show("The value you entered is way too big to be handled properly.");
                }
            }
        }

        private void tempBox1_TextChanged(object sender, EventArgs e)
        {
            if (tempBox1.Focused && tempBox1.Text.Length > 0)
            {
                try
                {
                    double value = Double.Parse(tempBox1.Text);
                    double answer = converter.convertTemp(tempComboBox1.SelectedIndex, tempComboBox2.SelectedIndex, value);
                    tempBox2.Text = answer.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("You entered an invalid value.");
                }
                catch (OverflowException)
                {
                    MessageBox.Show("The value you entered is way too big to be handled properly.");
                }
            }
        }

        private void tempBox2_TextChanged(object sender, EventArgs e)
        {
            if (tempBox2.Focused && tempBox2.Text.Length > 0)
            {
                try
                {
                    double value = Double.Parse(lengthBox2.Text);
                    double answer = converter.convertTemp(tempComboBox2.SelectedIndex, tempComboBox1.SelectedIndex, value);
                    tempBox1.Text = answer.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("You entered an invalid value.");
                }
                catch (OverflowException)
                {
                    MessageBox.Show("The value you entered is way too big to be handled properly.");
                }
            }
        }

        private void volumeBox1_TextChanged(object sender, EventArgs e)
        {
            if (volumeBox1.Focused && volumeBox1.Text.Length > 0)
            {
                try
                {
                    double value = Double.Parse(volumeBox1.Text);
                    double answer = converter.convertVolume(volumeComboBox1.SelectedIndex, volumeComboBox2.SelectedIndex, value);
                    volumeBox2.Text = answer.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("You entered an invalid value.");
                }
                catch (OverflowException)
                {
                    MessageBox.Show("The value you entered is way too big to be handled properly.");
                }
            }
        }

        private void volumeBox2_TextChanged(object sender, EventArgs e)
        {
            if (volumeBox2.Focused && volumeBox2.Text.Length > 0)
            {
                try
                {
                    double value = Double.Parse(volumeBox2.Text);
                    double answer = converter.convertVolume(volumeComboBox2.SelectedIndex, volumeComboBox1.SelectedIndex, value);
                    volumeBox1.Text = answer.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("You entered an invalid value.");
                }
                catch (OverflowException)
                {
                    MessageBox.Show("The value you entered is way too big to be handled properly.");
                }
            }
        }

        private void weightBox1_TextChanged(object sender, EventArgs e)
        {
            if (weightBox1.Focused && weightBox1.Text.Length > 0)
            {
                try
                {
                    double value = Double.Parse(weightBox1.Text);
                    double answer = converter.convertWeight(weightComboBox1.SelectedIndex, weightComboBox2.SelectedIndex, value);
                    weightBox2.Text = answer.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("You entered an invalid value.");
                }
                catch (OverflowException)
                {
                    MessageBox.Show("The value you entered is way too big to be handled properly.");
                }
            }
        }

        private void weightBox2_TextChanged(object sender, EventArgs e)
        {
            if (weightBox2.Focused && weightBox2.Text.Length > 0)
            {
                try
                {
                    double value = Double.Parse(weightBox2.Text);
                    double answer = converter.convertWeight(weightComboBox2.SelectedIndex, weightComboBox1.SelectedIndex, value);
                    weightBox1.Text = answer.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("You entered an invalid value.");
                }
                catch (OverflowException)
                {
                    MessageBox.Show("The value you entered is way too big to be handled properly.");
                }
            }
        }

        private void storeA1Button_Click(object sender, EventArgs e)
        {
            sharedData.store("A1", angleBox1.Text);
        }

        private void retrieveA1Button_Click(object sender, EventArgs e)
        {
            object data = sharedData.retrieve("A1");
            if (data == null)
            {
                MessageBox.Show("Variable A1 has not been set yet.");
            }
            else if (data.GetType() != typeof(double))
            {
                MessageBox.Show("Variable A1 has been stored of a different type.");
            }
            else
            {
                angleBox1.Text = data.ToString();
            }
        }

        private void storeA2Button_Click(object sender, EventArgs e)
        {
            sharedData.store("A2", angleBox2.Text);
        }

        private void retrieveA2Button_Click(object sender, EventArgs e)
        {
            object data = sharedData.retrieve("A2");
            if (data == null)
            {
                MessageBox.Show("Variable A2 has not been set yet.");
            }
            else if (data.GetType() != typeof(double))
            {
                MessageBox.Show("Variable A2 has been stored of a different type.");
            }
            else
            {
                angleBox2.Text = data.ToString();
            }
        }

        private void storeA3Button_Click(object sender, EventArgs e)
        {
            sharedData.store("A3", areaBox1.Text);
        }

        private void retrieveButtonA3_Click(object sender, EventArgs e)
        {
            object data = sharedData.retrieve("A3");
            if (data == null)
            {
                MessageBox.Show("Variable A3 has not been set yet.");
            }
            else if (data.GetType() != typeof(double))
            {
                MessageBox.Show("Variable A3 has been stored of a different type.");
            }
            else
            {
                areaBox1.Text = data.ToString();
            }
        }

        private void storeA4Button_Click(object sender, EventArgs e)
        {
            sharedData.store("A4", areaBox2.Text);
        }

        private void retrieveA4Button_Click(object sender, EventArgs e)
        {
            object data = sharedData.retrieve("A4");
            if (data == null)
            {
                MessageBox.Show("Variable A4 has not been set yet.");
            }
            else if (data.GetType() != typeof(double))
            {
                MessageBox.Show("Variable A4 has been stored of a different type.");
            }
            else
            {
                areaBox2.Text = data.ToString();
            }
        }

        private void storeL1Button_Click(object sender, EventArgs e)
        {
            sharedData.store("L1", lengthBox1.Text);
        }

        private void retrieveL1Button_Click(object sender, EventArgs e)
        {
            object data = sharedData.retrieve("L1");
            if (data == null)
            {
                MessageBox.Show("Variable L1 has not been set yet.");
            }
            else if (data.GetType() != typeof(double))
            {
                MessageBox.Show("Variable L1 has been stored of a different type.");
            }
            else
            {
                lengthBox1.Text = data.ToString();
            }
        }

        private void storeL2Button_Click(object sender, EventArgs e)
        {
            sharedData.store("L2", lengthBox2.Text);
        }

        private void retrieveL2Button_Click(object sender, EventArgs e)
        {
            object data = sharedData.retrieve("L2");
            if (data == null)
            {
                MessageBox.Show("Variable L2 has not been set yet.");
            }
            else if (data.GetType() != typeof(double))
            {
                MessageBox.Show("Variable L2 has been stored of a different type.");
            }
            else
            {
                lengthBox2.Text = data.ToString();
            }
        }

        private void storeT1Button_Click(object sender, EventArgs e)
        {
            sharedData.store("T1", tempBox1.Text);
        }

        private void retrieveT1Button_Click(object sender, EventArgs e)
        {
            object data = sharedData.retrieve("T1");
            if (data == null)
            {
                MessageBox.Show("Variable T1 has not been set yet.");
            }
            else if (data.GetType() != typeof(double))
            {
                MessageBox.Show("Variable T1 has been stored of a different type.");
            }
            else
            {
                tempBox1.Text = data.ToString();
            }
        }

        private void storeT2Button_Click(object sender, EventArgs e)
        {
            sharedData.store("T2", tempBox2.Text);
        }

        private void retrieveT2Button_Click(object sender, EventArgs e)
        {
            object data = sharedData.retrieve("T2");
            if (data == null)
            {
                MessageBox.Show("Variable T2 has not been set yet.");
            }
            else if (data.GetType() != typeof(double))
            {
                MessageBox.Show("Variable T2 has been stored of a different type.");
            }
            else
            {
                tempBox2.Text = data.ToString();
            }
        }

        private void storeV1Button_Click(object sender, EventArgs e)
        {
            sharedData.store("V1", volumeBox1.Text);
        }

        private void retrieveV1Button_Click(object sender, EventArgs e)
        {
            object data = sharedData.retrieve("V1");
            if (data == null)
            {
                MessageBox.Show("Variable V1 has not been set yet.");
            }
            else if (data.GetType() != typeof(double))
            {
                MessageBox.Show("Variable V1 has been stored of a different type.");
            }
            else
            {
                volumeBox1.Text = data.ToString();
            }
        }

        private void storeV2Button_Click(object sender, EventArgs e)
        {
            sharedData.store("V2", volumeBox2.Text);
        }

        private void retrieveV2Button_Click(object sender, EventArgs e)
        {
            object data = sharedData.retrieve("V2");
            if (data == null)
            {
                MessageBox.Show("Variable V2 has not been set yet.");
            }
            else if (data.GetType() != typeof(double))
            {
                MessageBox.Show("Variable V2 has been stored of a different type.");
            }
            else
            {
                volumeBox2.Text = data.ToString();
            }
        }

        private void storeW1Button_Click(object sender, EventArgs e)
        {
            sharedData.store("W1", weightBox1.Text);
        }

        private void retrieveW1Button_Click(object sender, EventArgs e)
        {
            object data = sharedData.retrieve("W1");
            if (data == null)
            {
                MessageBox.Show("Variable W1 has not been set yet.");
            }
            else if (data.GetType() != typeof(double))
            {
                MessageBox.Show("Variable W1 has been stored of a different type.");
            }
            else
            {
                weightBox1.Text = data.ToString();
            }
        }

        private void storeW2Button_Click(object sender, EventArgs e)
        {
            sharedData.store("W2", weightBox2.Text);
        }

        private void retrieveW2Button_Click(object sender, EventArgs e)
        {
            object data = sharedData.retrieve("W2");
            if (data == null)
            {
                MessageBox.Show("Variable W2 has not been set yet.");
            }
            else if (data.GetType() != typeof(double))
            {
                MessageBox.Show("Variable W2 has been stored of a different type.");
            }
            else
            {
                weightBox2.Text = data.ToString();
            }
        }

        private void angleComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double value = Double.Parse(angleBox2.Text);
                double answer = converter.convertAngle(angleComboBox2.SelectedIndex, angleComboBox1.SelectedIndex, value);
                angleBox1.Text = answer.ToString();
            }
            catch (FormatException)
            {
                angleBox2.Focus();
                MessageBox.Show("You entered an invalid value.");
            }
            catch (OverflowException)
            {
                angleBox2.Focus();
                MessageBox.Show("The value you entered is way too big to be handled properly.");
            }
        }

        private void angleComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double value = Double.Parse(angleBox1.Text);
                double answer = converter.convertAngle(angleComboBox1.SelectedIndex, angleComboBox2.SelectedIndex, value);
                angleBox2.Text = answer.ToString();
            }
            catch (FormatException)
            {
                angleBox1.Focus();
                MessageBox.Show("You entered an invalid value.");
            }
            catch (OverflowException)
            {
                angleBox1.Focus();
                MessageBox.Show("The value you entered is way too big to be handled properly.");
            }
        }

        private void areaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double value = Double.Parse(areaBox2.Text);
                double answer = converter.convertArea(areaComboBox2.SelectedIndex, areaComboBox1.SelectedIndex, value);
                areaBox1.Text = answer.ToString();
            }
            catch (FormatException)
            {
                areaBox2.Focus();
                MessageBox.Show("You entered an invalid value.");
            }
            catch (OverflowException)
            {
                areaBox2.Focus();
                MessageBox.Show("The value you entered is way too big to be handled properly.");
            }
        }

        private void areaComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double value = Double.Parse(areaBox2.Text);
                double answer = converter.convertArea(areaComboBox2.SelectedIndex, areaComboBox1.SelectedIndex, value);
                areaBox1.Text = answer.ToString();
            }
            catch (FormatException)
            {
                areaBox2.Focus();
                MessageBox.Show("You entered an invalid value.");
            }
            catch (OverflowException)
            {
                areaBox2.Focus();
                MessageBox.Show("The value you entered is way too big to be handled properly.");
            }
        }

        private void lengthComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double value = Double.Parse(lengthBox2.Text);
                double answer = converter.convertLength(lengthComboBox2.SelectedIndex, lengthComboBox1.SelectedIndex, value);
                lengthBox1.Text = answer.ToString();
            }
            catch (FormatException)
            {
                lengthBox2.Focus();
                MessageBox.Show("You entered an invalid value.");
            }
            catch (OverflowException)
            {
                lengthBox2.Focus();
                MessageBox.Show("The value you entered is way too big to be handled properly.");
            }
        }

        private void lengthComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double value = Double.Parse(lengthBox1.Text);
                double answer = converter.convertLength(lengthComboBox1.SelectedIndex, lengthComboBox2.SelectedIndex, value);
                lengthBox2.Text = answer.ToString();
            }
            catch (FormatException)
            {
                lengthBox1.Focus();
                MessageBox.Show("You entered an invalid value.");
            }
            catch (OverflowException)
            {
                lengthBox1.Focus();
                MessageBox.Show("The value you entered is way too big to be handled properly.");
            }
        }

        private void tempComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double value = Double.Parse(tempBox2.Text);
                double answer = converter.convertTemp(tempComboBox2.SelectedIndex, tempComboBox1.SelectedIndex, value);
                tempBox1.Text = answer.ToString();
            }
            catch (FormatException)
            {
                tempBox2.Focus();
                MessageBox.Show("You entered an invalid value.");
            }
            catch (OverflowException)
            {
                tempBox2.Focus();
                MessageBox.Show("The value you entered is way too big to be handled properly.");
            }
        }

        private void tempComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double value = Double.Parse(tempBox1.Text);
                double answer = converter.convertTemp(tempComboBox1.SelectedIndex, tempComboBox2.SelectedIndex, value);
                tempBox2.Text = answer.ToString();
            }
            catch (FormatException)
            {
                tempBox1.Focus();
                MessageBox.Show("You entered an invalid value.");
            }
            catch (OverflowException)
            {
                tempBox1.Focus();
                MessageBox.Show("The value you entered is way too big to be handled properly.");
            }
        }

        private void volumeComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double value = Double.Parse(volumeBox2.Text);
                double answer = converter.convertVolume(volumeComboBox2.SelectedIndex, volumeComboBox1.SelectedIndex, value);
                volumeBox1.Text = answer.ToString();
            }
            catch (FormatException)
            {
                volumeBox2.Focus();
                MessageBox.Show("You entered an invalid value.");
            }
            catch (OverflowException)
            {
                volumeBox2.Focus();
                MessageBox.Show("The value you entered is way too big to be handled properly.");
            }
        }

        private void volumeComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double value = Double.Parse(volumeBox1.Text);
                double answer = converter.convertVolume(volumeComboBox1.SelectedIndex, volumeComboBox2.SelectedIndex, value);
                volumeBox2.Text = answer.ToString();
            }
            catch (FormatException)
            {
                volumeBox1.Focus();
                MessageBox.Show("You entered an invalid value.");
            }
            catch (OverflowException)
            {
                volumeBox1.Focus();
                MessageBox.Show("The value you entered is way too big to be handled properly.");
            }
        }

        private void weightComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double value = Double.Parse(weightBox2.Text);
                double answer = converter.convertWeight(weightComboBox2.SelectedIndex, weightComboBox1.SelectedIndex, value);
                weightBox1.Text = answer.ToString();
            }
            catch (FormatException)
            {
                weightBox2.Focus();
                MessageBox.Show("You entered an invalid value.");
            }
            catch (OverflowException)
            {
                weightBox2.Focus();
                MessageBox.Show("The value you entered is way too big to be handled properly.");
            }
        }

        private void weightComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double value = Double.Parse(weightBox1.Text);
                double answer = converter.convertWeight(weightComboBox1.SelectedIndex, weightComboBox2.SelectedIndex, value);
                weightBox2.Text = answer.ToString();
            }
            catch (FormatException)
            {
                weightBox1.Focus();
                MessageBox.Show("You entered an invalid value.");
            }
            catch (OverflowException)
            {
                weightBox1.Focus();
                MessageBox.Show("The value you entered is way too big to be handled properly.");
            }
        }
    }
}
