namespace labar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        PictureBox[] p = new PictureBox[4];
        int[] nums = new int[4];
        int count;
        int cheat = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox4.Image = new Bitmap("up.jpg");
            p[1] = pictureBox1;
            p[2] = pictureBox2;
            p[3] = pictureBox3;
            //��J��l�Ϥ�
            for (int i = 1; i <= p.GetUpperBound(0); i++)
            {
                p[i].Image = new Bitmap("0.jpg");
                p[i].SizeMode = PictureBoxSizeMode.StretchImage;
            }

            label2.Text = "50";
            timer1.Interval = 100;
            numericUpDown1.Value = 5;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //�P�_ ��`�q �O�_�j�� 0 �� ��`�q�O�_�p�󵥩� �`�ƶq
            if (numericUpDown1.Value > 0 && numericUpDown1.Value <= Convert.ToInt32(label2.Text))
            {
                pictureBox4.Image = new Bitmap("down.jpg");
                timer1.Enabled = true;

                cheat += 1;
                //cheat = cheat +1;
                label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) - numericUpDown1.Value);
                
            }
            else
            {
                MessageBox.Show("��`���~");
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            for(int i =1; i <= p.GetUpperBound(0);i++)
            {
                nums[i] = r.Next(0,4); // 0~3
                p[i].Image = new Bitmap(Convert.ToString(nums[i])+".jpg"); // num[i].jpg
            }
            count += 1;
            if (count == 20)
            {
                if(cheat %3==0)
                {
                    nums[1] = nums[2] = nums[3];
                    p[1].Image = p[2].Image = p[3].Image;
                }
                timer1.Enabled = false;
                if (nums[1]==0 && nums[2] == 0 && nums[3] == 0)
                {
                    label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + numericUpDown1.Value * 5);
                    MessageBox.Show("���ߤ����A��`�q*5");
                }
                else if (nums[1] == 1 && nums[2] == 1 && nums[3] == 1)
                {
                    label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + numericUpDown1.Value * 10);
                    MessageBox.Show("���ߤ����A��`�q*10");
                }
                else if (nums[1] == 2 && nums[2] == 2 && nums[3] == 2)
                {
                    label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + numericUpDown1.Value * 15);
                    MessageBox.Show("���ߤ����A��`�q*15");
                }
                else if (nums[1] == 3 && nums[2] == 3 && nums[3] == 3)
                {
                    label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + numericUpDown1.Value * 20);
                    MessageBox.Show("���ߤ����A��`�q*20");
                }
                pictureBox4.Image = new Bitmap("up.jpg");
                count = 0;
            }


        }
    }
}