namespace percentCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pointInDiRatioCheck.SelectedIndex = 0;
            multiLang.SelectedIndex = 0;
            this.ActiveControl = resetButton;


            multiLang.Visible = false;  // �̱���
        }

        // �ʱ�ȭ ��ư Ŭ��
        private void resetButton_click(object sender, EventArgs e)
        {
            // ��� �ؽ�Ʈ�ڽ� �� �����
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    if (textBox != null) textBox.Text = string.Empty;
                }
            }

            // ������� �ѹ��� �����ش�.
            totalRatioText3.Text = string.Empty;
            totalValuesText3.Text = string.Empty;
            pointInDeText3.Text = string.Empty;
            pointInDiRatioText3.Text = string.Empty;

            // ����/���� �󺧰� ����
            pointInDeLabel4.Text = string.Empty;

            pointInDiRatioCheck.SelectedIndex = 0;
        }

        // �׻� ���� ǥ�� �̺�Ʈ
        private void fixCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }

        // �������� �̺�Ʈ
        private void numberFormatCheckChanged(object sender, EventArgs e)
        {
            if((sender as CheckBox).Checked)
            {
                // ��� �ؽ�Ʈ�ڽ� �������� �ٲٱ�
                foreach (Control control in this.Controls)
                {
                    if (control is TextBox)
                    {
                        if (!control.Name.Equals("totalRatioText3") &&
                            !control.Name.Equals("totalValuesText3") &&
                            !control.Name.Equals("pointInDeText3") &&
                            !control.Name.Equals("pointInDiRatioText3"))
                        {
                            TextBox textBox = (TextBox)control;
                            double convertNum = 0;
                            double.TryParse(textBox.Text, out convertNum);
                            if (textBox != null && convertNum != 0) textBox.Text = string.Format("{0:#,##0}", convertNum);
                        }
                    }
                }
            }
            else
            {
                // ��� �ؽ�Ʈ�ڽ� �������� �ٲٱ�
                foreach (Control control in this.Controls)
                {
                    if (control is TextBox)
                    {
                        if (!control.Name.Equals("totalRatioText3") &&
                            !control.Name.Equals("totalValuesText3") &&
                            !control.Name.Equals("pointInDeText3") &&
                            !control.Name.Equals("pointInDiRatioText3"))
                        {
                            TextBox textBox = (TextBox)control;
                            double convertNum = 0;
                            double.TryParse(textBox.Text, out convertNum);
                            if (textBox != null && convertNum != 0) textBox.Text = string.Format("{0:0} ", convertNum);
                        }
                    }
                }
            }
            
        }

        // �ٱ��� �̺�Ʈ
        private void multiLangChanged(object sender, EventArgs e)
        {

        }

        // ���ڸ� �Է¹ޱ�
        private void onlyNumber(object sender, KeyPressEventArgs e)
        {
            // ���ڿ� '.' ���
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                 (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // ���� '.' 1���� ���
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        // ��ü�� �������� ��� �̺�Ʈ
        private void totalRatioTextChanged(object sender, EventArgs e)
        {
            // �� ��������
            double result = 0;
            double totalRatioText1_value = 0;
            double totalRatioText2_value = 0;
            if((sender as TextBox).Name == "totalRatioText1")
            {
                double.TryParse((sender as TextBox).Text.Replace(",", ""), out totalRatioText1_value);
                double.TryParse(totalRatioText2.Text, out totalRatioText2_value);
            }
            else
            {
                double.TryParse(totalRatioText1.Text, out totalRatioText1_value);
                double.TryParse((sender as TextBox).Text, out totalRatioText2_value);
            }

            // ������
            double divCal = totalRatioText2_value / 100;
            if (!double.IsNaN(divCal)) // �� üũ
            {
                if (double.IsInfinity(divCal)) // ���� üũ
                {
                    result = 0;
                }
                else
                {
                    result = totalRatioText1_value * divCal;
                }
            }
            else
            {
                result = 0;
            }

            // ���
            string format = "";
            if (numberFormatCheck.Checked)
            {
                format = string.Format("{0:#,##0.00} ", result);
            }
            else
            {
                format = string.Format("{0:0.00} ", result);
            }
            
            totalRatioText3.Text = format;
        }

        // ��ü�� ������ ���� ��� �̺�Ʈ
        private void totalValuesTextChanged(object sender, EventArgs e)
        {
            // �� ��������
            double result = 0;
            double totalValuesText1_value = 0;
            double totalValuesText2_value = 0;
            if ((sender as TextBox).Name == "totalValuesText1")
            {
                double.TryParse((sender as TextBox).Text, out totalValuesText1_value);
                double.TryParse(totalValuesText2.Text, out totalValuesText2_value);
            }
            else
            {
                double.TryParse(totalValuesText1.Text, out totalValuesText1_value);
                double.TryParse((sender as TextBox).Text, out totalValuesText2_value);
            }
            
            // ������
            double divCal = totalValuesText2_value / totalValuesText1_value;
            if (!double.IsNaN(divCal)) // �� üũ
            {
                if (double.IsInfinity(divCal)) // ���� üũ
                {
                    result = 0;
                }
                else
                {
                    result = 100 * divCal;
                }   
            }
            else
            {
                result = 0;
            }

            // ���
            string format = string.Format("{0:0.00} ", result);
            totalValuesText3.Text = format;
        }


        // ���ذ� �󸶳� ����/�����ߴ��� ��� �̺�Ʈ
        private void pointInDeTextChanged(object sender, EventArgs e)
        {
            bool labelCheck = true;

            // �� ��������
            double result = 0;
            double pointInDeText1_value = 0;
            double pointInDeText2_value = 0;
            if ((sender as TextBox).Name == "pointInDeText1")
            {
                double.TryParse((sender as TextBox).Text, out pointInDeText1_value);
                double.TryParse(pointInDeText2.Text, out pointInDeText2_value);
                if ((sender as TextBox).Text.Equals("") || pointInDeText2.Text.Equals(""))
                {
                    labelCheck = false;
                }
            }
            else
            {
                double.TryParse(pointInDeText1.Text, out pointInDeText1_value);
                double.TryParse((sender as TextBox).Text, out pointInDeText2_value);
                if (pointInDeText1.Text.Equals("") || (sender as TextBox).Text.Equals(""))
                {
                    labelCheck = false;
                }
            }

            // ������
            // ���϶� ����/���� �� �����
            if(pointInDeText1_value == 0 || pointInDeText2_value == 0)
            {
                pointInDeLabel4.Text = string.Empty;
            }

            double divCal = ((pointInDeText2_value - pointInDeText1_value) / pointInDeText1_value);
            if (!double.IsNaN(divCal)) // �� üũ
            {
                if (double.IsInfinity(divCal)) // ���� üũ
                {
                    result = 0;
                }
                else
                {
                    result = divCal * 100;
                }
            } 
            else
            {
                result = 0;
            }

            // ���
            if (labelCheck)
            {
                if (result < 0)
                {
                    pointInDeLabel4.Text = "����";
                    pointInDeLabel4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f58222");
                }
                else
                {
                    pointInDeLabel4.Text = "����";
                    pointInDeLabel4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f58222");
                }
            }
            else
            {
                pointInDeLabel4.Text = string.Empty;
            }

            string format = string.Format("{0:0.00} ", Math.Abs(result));
            pointInDeText3.Text = format;
        }


        // ���ذ� �������� ��� �̺�Ʈ
        private void pointInDiRatioTextChanged(object sender, EventArgs e)
        {
            // �� ��������
            double result = 0;
            double pointInDiRatioText1_value = 0;
            double pointInDiRatioText2_value = 0;
            int pointInDiRatioCheck_value = 0;
            if ((sender as TextBox).Name == "pointInDiRatioText1")
            {
                double.TryParse((sender as TextBox).Text, out pointInDiRatioText1_value);
                double.TryParse(pointInDiRatioText2.Text, out pointInDiRatioText2_value);

                String selectText = pointInDiRatioCheck.SelectedItem.ToString();
                if (selectText.Equals("����"))
                {
                    pointInDiRatioCheck_value = 1;
                }
                else
                {
                    pointInDiRatioCheck_value = -1;
                }
            }
            else
            {
                double.TryParse(pointInDiRatioText1.Text, out pointInDiRatioText1_value);
                double.TryParse((sender as TextBox).Text, out pointInDiRatioText2_value);

                String selectText = pointInDiRatioCheck.SelectedItem.ToString();
                if (selectText.Equals("����"))
                {
                    pointInDiRatioCheck_value = 1;
                }
                else
                {
                    pointInDiRatioCheck_value = -1;
                }
            }


            // ������
            double divCal = pointInDiRatioText1_value * (pointInDiRatioText2_value / 100);
            if (!double.IsNaN(divCal)) // �� üũ
            {
                if (double.IsInfinity(divCal)) // ���� üũ
                {
                    result = 0;
                }
                else
                {
                    result = pointInDiRatioText1_value + (divCal * pointInDiRatioCheck_value);
                }
            }
            else
            {
                result = 0;
            }

            // ���
            string format = "";
            if (numberFormatCheck.Checked)
            {
                format = string.Format("{0:#,##0.00} ", Math.Abs(result));
            }
            else
            {
                format = string.Format("{0:0.00} ", Math.Abs(result));
            }
            pointInDiRatioText3.Text = format;
        }

        private void pointInDiRatioComboChanged(object sender, EventArgs e)
        {
            // �� ��������
            double result = 0;
            double pointInDiRatioText1_value = 0;
            double pointInDiRatioText2_value = 0;
            int pointInDiRatioCheck_value = 0;

            double.TryParse(pointInDiRatioText1.Text, out pointInDiRatioText1_value);
            double.TryParse(pointInDiRatioText2.Text, out pointInDiRatioText2_value);
            String selectText = (sender as ComboBox).SelectedItem.ToString();
            if (selectText.Equals("����"))
            {
                pointInDiRatioCheck_value = 1;
            }
            else
            {
                pointInDiRatioCheck_value = -1;
            }

            // ������
            double divCal = pointInDiRatioText1_value * (pointInDiRatioText2_value / 100);
            if (!double.IsNaN(divCal)) // �� üũ
            {
                if (double.IsInfinity(divCal)) // ���� üũ
                {
                    result = 0;
                }
                else
                {
                    result = pointInDiRatioText1_value + (divCal * pointInDiRatioCheck_value);
                }
            }
            else
            {
                result = 0;
            }

            // ���
            string format = "";
            if (numberFormatCheck.Checked)
            {
                format = string.Format("{0:#,##0.00} ", Math.Abs(result));
            }
            else
            {
                format = string.Format("{0:0.00} ", Math.Abs(result));
            }
            pointInDiRatioText3.Text = format;
        }

        private void focusLeave(object sender, EventArgs e)
        {
            if (numberFormatCheck.Checked)
            {
                double convertNum = 0;
                double.TryParse((sender as TextBox).Text.Replace(",", ""), out convertNum);
                if(convertNum != 0)
                {
                    (sender as TextBox).Text = string.Format("{0:#,##0}", convertNum);
                }
            }
        }
    }

    
}