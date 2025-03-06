namespace RotatingCube
{
    public partial class Form1 : Form
    {
        private Pen pen = new Pen(Color.Black, 5f);
        private Cube[] cubes = new Cube[1];

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < cubes.Length; i++)
            {
                cubes[i] = new Cube(this, 200, 10, 20, 100);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            g.TranslateTransform(ClientSize.Width / 2, ClientSize.Height / 2);
            g.ScaleTransform(1, -1);

            cubes[0].position.x += 1;

            foreach (Cube cube in cubes) cube.Draw(g);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
