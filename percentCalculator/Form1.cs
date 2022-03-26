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
            this.ActiveControl = resetButton;
        }

        /*
         *
         *      result_a: function() {
                    return "" === String(this.num_a_1) || "" === String(this.num_a_2) ? "" : t(this.num_a_1 * (this.num_a_2 / 100), 2)
                },
                result_b: function() {
                    return "" === String(this.num_b_1) || "" === String(this.num_b_2) ? "" : t(100 * this.num_b_2 / this.num_b_1, 2)
                },
                result_c: function() {
                    if ("" === String(this.num_c_1) || "" === String(this.num_c_2)) return this.result_c_t = "", "";
                    var n = t((this.num_c_2 - this.num_c_1) / this.num_c_1 * 100, 2);
                    return this.result_c_t = n > 0 ? "����" : n < 0 ? "����" : "", Math.abs(n)
                },
                result_d: function() {
                    return "" === String(this.num_d_1) || "" === String(this.num_d_2) ? "" : t(parseFloat(this.num_d_1) + this.num_d_1 * (this.num_d_2 / 100) * this.num_d_3, 2)
                }
         * 
         */

        
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

            pointInDiRatioCheck.SelectedIndex = 0;
        }

        // �׻� ���� ǥ�� �̺�Ʈ
        private void fixCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
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
                double.TryParse((sender as TextBox).Text, out totalRatioText1_value);
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
            string format = string.Format("{0:0.00} ", result);
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
            // �� ��������
            double result = 0;
            double pointInDeText1_value = 0;
            double pointInDeText2_value = 0;
            if ((sender as TextBox).Name == "pointInDeText1")
            {
                double.TryParse((sender as TextBox).Text, out pointInDeText1_value);
                double.TryParse(pointInDeText2.Text, out pointInDeText2_value);
            }
            else
            {
                double.TryParse(pointInDeText1.Text, out pointInDeText1_value);
                double.TryParse((sender as TextBox).Text, out pointInDeText2_value);
            }

            // ������
            // ���϶� ����/���� �� �����
            if(pointInDeText1_value == 0 || pointInDeText2_value == 0)
            {
                pointInDeLabel4.Text = "";
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
            if(result < 0)
            {
                pointInDeLabel4.Text = "����";
                pointInDeLabel4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f58222");
            }
            else
            {
                pointInDeLabel4.Text = "����";
                pointInDeLabel4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f58222");
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
            string format = string.Format("{0:0.00} ", Math.Abs(result));
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
            string format = string.Format("{0:0.00} ", Math.Abs(result));
            pointInDiRatioText3.Text = format;
        }
    }

    
}