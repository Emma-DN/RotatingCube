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
public class Pt2d
{
    public double x { get; set; }
    public double y { get; set; }

    public Pt2d(double x, double y)
    {
        this.x = x;
        this.y = y;
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
        //Random r = new Random();
        //x = r.Next(-form.ClientSize.Width / 2, form.ClientSize.Width / 2);
        //y = r.Next(-form.ClientSize.Height / 2, form.ClientSize.Height / 2);
        //z = r.Next(0, form.ClientSize.Height);

        x = 0;
        y = 0;
        z = 20;

        position = new Pt(x, y, z);
        this.scale = scale;

        // Define closer(larger) square points in relation to the center
        model.Add(new Pt(-1, 1, 1));
        model.Add(new Pt(1, 1, 1));
        model.Add(new Pt(1, -1, 1));
        model.Add(new Pt(-1, -1, 1));

        // Define further(smaller) square points in relation to the center
        model.Add(new Pt(-1, 1, 3));
        model.Add(new Pt(1, 1, 3));
        model.Add(new Pt(1, -1, 3));
        model.Add(new Pt(-1, -1, 3));
    }

    public void Draw(Graphics g)
    {
        List<Pt> worldPoints = new List<Pt>();
        List<Pt2d> xyPoints = new List<Pt2d>();

        // Convert local points to world points and 2D coordinates
        foreach (Pt p in model)
        {
            var wp = ToWorldPoint(p);
            worldPoints.Add(wp);
            var xp = ToXYPoint(wp);
            xyPoints.Add(xp);
        }

        // Draw squares
        foreach (Pt2d point in xyPoints)
        {
            int pointIndex = xyPoints.IndexOf(point);

            if (pointIndex == 3 || pointIndex == 7)
            {
                DrawLine(g, point, xyPoints[pointIndex - 3]);
            }
            else
            {
                DrawLine(g, point, xyPoints[pointIndex + 1]);
            }
        }

        // Draw connecting lines
        for (int i = 0; i < 4; i++)
        {
            DrawLine(g, xyPoints[i], xyPoints[i + 4]);
        }
    }

    // Convert local point to world point
    public Pt ToWorldPoint(Pt p)
    {
        return new Pt((int)(position.x + p.x * scale), (int)(position.y + p.y * scale), (int)(position.z + p.z * scale));
    }

    // Convert 3D point to 2D coordinates
    public Pt2d ToXYPoint(Pt p)
    {
        int height = 100;
        return new Pt2d(p.x / p.z * height, p.y / p.z * height);
    }

    // Draw a line between two points
    public void DrawLine(Graphics g, Pt2d p1, Pt2d p2)
    {
        g.DrawLine(pen, (int)p1.x, (int)p1.y, (int)p2.x, (int)p2.y);
    }
}
