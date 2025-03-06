using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotatingCube;

public class Pt
{
    public double x { get; set; }
    public double y { get; set; }
    public double z { get; set; }

    public Pt(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}
public class Cube
{
    public Pt position;
    private double scale;
    private List<Pt> model = new List<Pt>();
    private Form1 form;

    private Pen pen = new Pen(Color.Black, 5f);

    public Cube(Form1 f, int x, int y, int z, int scale)
    {
        form = f;
        // Create cube at a random position
        Random r = new Random();
        x = r.Next(-form.ClientSize.Width / 2, form.ClientSize.Width / 2);
        y = r.Next(-form.ClientSize.Height / 2, form.ClientSize.Height / 2);
        z = r.Next(0, form.ClientSize.Height);

        position = new Pt(x, y, z);
        this.scale = scale;

        model.Add(new Pt(-1, 1, -1));
        model.Add(new Pt(1, 1, -1));
        model.Add(new Pt(1, -1, -1));
        model.Add(new Pt(-1, -1, -1));
    }

    public void Draw(Graphics g)
    {
        List<Pt> points = new List<Pt>();

        foreach (Pt p in model)
        {
            points.Add(new Pt((int)(position.x + p.x * scale), (int)(position.y + p.y * scale), (int)(position.z + p.z * scale)));
        }

        g.DrawLine(pen, (int)points[0].x, (int)points[0].y, (int)points[1].x, (int)points[1].y);
        g.DrawLine(pen, (int)points[1].x, (int)points[1].y, (int)points[2].x, (int)points[2].y);
        g.DrawLine(pen, (int)points[2].x, (int)points[2].y, (int)points[3].x, (int)points[3].y);
        g.DrawLine(pen, (int)points[3].x, (int)points[3].y, (int)points[0].x, (int)points[0].y);
    }
}
