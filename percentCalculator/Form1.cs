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
            // '.' �������ϱ�
            string[] StringArray = (sender as TextBox).Text.Split(new string[] { "." }, StringSplitOptions.None);
            int pointNum = StringArray.Length - 1;

            //���ڸ� �Էµǵ��� ���͸�
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)) || (e.KeyChar == '.'))
            {
                if (pointNum < 2)
                {
                    e.Handled = false;
                }
            }
        }

        // ��ü�� �������� ��� �̺�Ʈ
        private void totalRatioTextChanged(object sender, EventArgs e)
        {
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

            result = totalRatioText1_value * (totalRatioText2_value / 100);

            string format = string.Format("{0:0.00} ", result);

            totalRatioText3.Text = format;
        }

        
    }
}