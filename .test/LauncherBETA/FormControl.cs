using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LauncherKG
{
  [ToolboxBitmap("PBEX.bmp")]
  public class FormControl : Control
  {
    private Blend F0 = new Blend();
    private int F1;
    private int F2 = 100;
    private int F3;
    private bool F4 = true;
    private Pen F5;
    private Color F6 = Color.Black;
    private FormControl.T34 F7;
    private Color F8 = Color.White;
    private Color F9 = Color.DarkGray;
    private Color F10 = Color.Lime;
    private SolidBrush F11;
    private bool F12;
    private bool F13;
    private FormControl.T35 F14;
    private Bitmap F15;
    private bool F16 = true;
    private FormControl.T36 F17;

    public FormControl()
    {
      this.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);
      base.TabStop = false;
      this.Size = new Size(200, 23);
      this.F0.Positions = new float[6]
      {
        0.0f,
        0.2f,
        0.4f,
        0.6f,
        0.8f,
        1f
      };
      this.P11 = FormControl.T34.F121;
      base.BackColor = Color.Transparent;
      this.F11 = new SolidBrush(base.ForeColor);
      this.F5 = new Pen(Color.Black);
    }

    [Description("The foreground color of the ProgressBars text.")]
    [Category("Appearance")]
    [Browsable(true)]
    public virtual Color P0
    {
      get => base.ForeColor;
      set
      {
        if (value == Color.Transparent)
          value = this.F11.Color;
        base.ForeColor = value;
        this.F11.Color = value;
      }
    }

    [Browsable(true)]
    [DefaultValue(typeof (Color), "DarkGray")]
    [Category("Appearance")]
    [Description("The background color of the ProgressBar.")]
    public Color P1
    {
      get => this.F9;
      set
      {
        if (value == Color.Transparent)
          value = this.F9;
        this.F9 = value;
        this.Refresh();
      }
    }

    [DefaultValue(typeof (Color), "Lime")]
    [Category("Appearance")]
    [Browsable(true)]
    [Description("The progress color of the ProgressBar.")]
    public Color P2
    {
      get => this.F10;
      set
      {
        if (value == Color.Transparent)
          value = this.F10;
        this.F10 = value;
        this.Refresh();
      }
    }

    [DefaultValue(typeof (Color), "White")]
    [Category("Appearance")]
    [Description("The gradiant highlight color of the ProgressBar.")]
    [Browsable(true)]
    public Color P3
    {
      get => this.F8;
      set
      {
        this.F8 = value;
        this.Refresh();
      }
    }

    [Browsable(true)]
    [DefaultValue(0)]
    [Description("The minimum value of the ProgressBar.")]
    [Category("Behavior")]
    public int P4
    {
      get => this.F1;
      set
      {
        if (value > this.F2)
          value = this.F2 - 1;
        this.F1 = value;
        this.Refresh();
      }
    }

    [Browsable(true)]
    [DefaultValue(100)]
    [Category("Behavior")]
    [Description("The maximum value of the ProgressBar.")]
    public int P5
    {
      get => this.F2;
      set
      {
        if (value <= this.F1)
          value = this.F1 + 1;
        this.F2 = value;
        this.Refresh();
      }
    }

    [Browsable(true)]
    [DefaultValue(0)]
    [Category("Behavior")]
    [Description("The current value of the ProgressBar.")]
    public int P6
    {
      get => this.F3;
      set
      {
        if (value < this.F1)
          value = this.F1;
        if (value > this.F2)
          value = this.F2;
        this.F3 = value;
        this.Refresh();
      }
    }

    [DefaultValue(true)]
    [Category("Appearance")]
    [Description("Draw a border around the ProgressBar.")]
    [Browsable(true)]
    public bool P7
    {
      get => this.F4;
      set
      {
        this.F4 = value;
        this.Refresh();
      }
    }

    [Description("The color of the border around the ProgressBar.")]
    [Browsable(true)]
    [Category("Appearance")]
    [DefaultValue(typeof (Color), "Black")]
    public Color P8
    {
      get => this.F6;
      set
      {
        if (value == Color.Transparent)
          value = this.F6;
        this.F6 = value;
        this.F5.Color = value;
        this.Refresh();
      }
    }

    [Browsable(true)]
    [DefaultValue(false)]
    [Category("Appearance")]
    [Description("Shows the progress percentge as text in the ProgressBar.")]
    public bool P9
    {
      get => this.F12;
      set
      {
        this.F12 = value;
        this.Refresh();
      }
    }

    [Description("Shows the text of the Text property in the ProgressBar.")]
    [DefaultValue(false)]
    [Browsable(true)]
    [Category("Appearance")]
    public bool P10
    {
      get => this.F13;
      set
      {
        this.F13 = value;
        this.Refresh();
      }
    }

    [Description("Determins the position of the gradiant shine in the ProgressBar.")]
    //[DefaultValue(typeof (ProgressBarEx.ProgressBarEx.GradiantArea), "Top")]
    [Browsable(true)]
    [Category("Appearance")]
    public FormControl.T34 P11
    {
      get => this.F7;
      set
      {
        this.F7 = value;
        switch (value)
        {
          case FormControl.T34.F120:
            this.F0.Factors = new float[6];
            break;
          case FormControl.T34.F121:
            this.F0.Factors = new float[6]
            {
              0.8f,
              0.7f,
              0.6f,
              0.4f,
              0.0f,
              0.0f
            };
            break;
          case FormControl.T34.F122:
            this.F0.Factors = new float[6]
            {
              0.0f,
              0.4f,
              0.6f,
              0.6f,
              0.4f,
              0.0f
            };
            break;
          default:
            this.F0.Factors = new float[6]
            {
              0.0f,
              0.0f,
              0.4f,
              0.6f,
              0.7f,
              0.8f
            };
            break;
        }
        this.Refresh();
      }
    }

    [Description("An image to display on the ProgressBarEx.")]
    [Category("Appearance")]
    [Browsable(true)]
    public Bitmap P12
    {
      get => this.F15;
      set
      {
        this.F15 = value;
        this.Refresh();
      }
    }

    [Description("Determins how the image is displayed in the ProgressBarEx.")]
    [Category("Appearance")]
    //[DefaultValue(typeof (ProgressBarEx.ProgressBarEx.ImageLayoutType), "None")]
    [Browsable(true)]
    public FormControl.T35 P13
    {
      get => this.F14;
      set
      {
        this.F14 = value;
        if (this.F15 == null)
          return;
        this.Refresh();
      }
    }

    [Description("True to draw corners rounded. False to draw square corners.")]
    [Browsable(true)]
    [DefaultValue(true)]
    [Category("Appearance")]
    public bool P14
    {
      get => this.F16;
      set
      {
        this.F16 = value;
        this.Refresh();
      }
    }

    //[DefaultValue(typeof (ProgressBarEx.ProgressBarEx.ProgressDir), "Horizontal")]
    [Description("Determins the direction of progress displayed in the ProgressBarEx.")]
    [Browsable(true)]
    [Category("Appearance")]
    public FormControl.T36 P15
    {
      get => this.F17;
      set
      {
        this.F17 = value;
        this.Refresh();
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      Point point1 = new Point(0, 0);
      Point point2 = new Point(0, this.Height);
      if (this.F17 == FormControl.T36.F128)
        point2 = new Point(this.Width, 0);
      using (GraphicsPath path1 = new GraphicsPath())
      {
        Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
        int int32_1 = Convert.ToInt32((double) rect.Height / 2.5);
        if (rect.Width < rect.Height)
          int32_1 = Convert.ToInt32((double) rect.Width / 2.5);
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(point1, point2, this.F9, this.F8))
        {
          linearGradientBrush.Blend = this.F0;
          if (this.F16)
          {
            path1.AddArc(rect.X, rect.Y, int32_1, int32_1, 180f, 90f);
            path1.AddArc(rect.Right - int32_1, rect.Y, int32_1, int32_1, 270f, 90f);
            path1.AddArc(rect.Right - int32_1, rect.Bottom - int32_1, int32_1, int32_1, 0.0f, 90f);
            path1.AddArc(rect.X, rect.Bottom - int32_1, int32_1, int32_1, 90f, 90f);
            path1.CloseFigure();
            e.Graphics.FillPath((Brush) linearGradientBrush, path1);
          }
          else
            e.Graphics.FillRectangle((Brush) linearGradientBrush, rect);
        }
        if (this.F3 > this.F1)
        {
          int int32_2 = Convert.ToInt32((double) this.Width / (double) (this.F2 - this.F1) * (double) this.F3);
          if (this.F17 == FormControl.T36.F128)
          {
            int int32_3 = Convert.ToInt32((double) this.Height / (double) (this.F2 - this.F1) * (double) this.F3);
            rect.Y = rect.Height - int32_3;
            rect.Height = int32_3;
          }
          else
            rect.Width = int32_2;
          using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(point1, point2, this.F10, this.F8))
          {
            linearGradientBrush.Blend = this.F0;
            if (this.F16)
            {
              if (this.F17 == FormControl.T36.F127)
                --rect.Height;
              else
                --rect.Width;
              using (GraphicsPath path2 = new GraphicsPath())
              {
                path2.AddArc(rect.X, rect.Y, int32_1, int32_1, 180f, 90f);
                path2.AddArc(rect.Right - int32_1, rect.Y, int32_1, int32_1, 270f, 90f);
                path2.AddArc(rect.Right - int32_1, rect.Bottom - int32_1, int32_1, int32_1, 0.0f, 90f);
                path2.AddArc(rect.X, rect.Bottom - int32_1, int32_1, int32_1, 90f, 90f);
                path2.CloseFigure();
                using (GraphicsPath path3 = new GraphicsPath())
                {
                  using (Region region = new Region(path1))
                  {
                    region.Intersect(path2);
                    path3.AddRectangles(region.GetRegionScans(new Matrix()));
                  }
                  e.Graphics.FillPath((Brush) linearGradientBrush, path3);
                }
              }
            }
            else
              e.Graphics.FillRectangle((Brush) linearGradientBrush, rect);
          }
        }
        if (this.F15 != null)
        {
          if (this.F14 == FormControl.T35.F126)
            e.Graphics.DrawImage((Image) this.F15, 0, 0, this.Width, this.Height);
          else if (this.F14 == FormControl.T35.F124)
          {
            e.Graphics.DrawImage((Image) this.F15, 0, 0);
          }
          else
          {
            int int32_2 = Convert.ToInt32(this.Width / 2 - this.F15.Width / 2);
            int int32_3 = Convert.ToInt32(this.Height / 2 - this.F15.Height / 2);
            e.Graphics.DrawImage((Image) this.F15, int32_2, int32_3);
          }
        }
        if (this.F12 | this.F13)
        {
          string s = "";
          if (this.F13)
            s = this.Text;
          if (this.F12)
            s = s + Convert.ToString(Convert.ToInt32(100.0 / (double) (this.F2 - this.F1) * (double) this.F3)) + "%";
          using (StringFormat format = new StringFormat()
          {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
          })
            e.Graphics.DrawString(s, this.Font, (Brush) this.F11, (RectangleF) new Rectangle(0, 0, this.Width, this.Height), format);
        }
        if (!this.F4)
          return;
        rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
        if (this.F16)
        {
          path1.Reset();
          path1.AddArc(rect.X, rect.Y, int32_1, int32_1, 180f, 90f);
          path1.AddArc(rect.Right - int32_1, rect.Y, int32_1, int32_1, 270f, 90f);
          path1.AddArc(rect.Right - int32_1, rect.Bottom - int32_1, int32_1, int32_1, 0.0f, 90f);
          path1.AddArc(rect.X, rect.Bottom - int32_1, int32_1, int32_1, 90f, 90f);
          path1.CloseFigure();
          e.Graphics.DrawPath(this.F5, path1);
        }
        else
          e.Graphics.DrawRectangle(this.F5, rect);
      }
    }

    protected override void OnTextChanged(EventArgs e)
    {
      this.Refresh();
      base.OnTextChanged(e);
    }

    protected override void Dispose(bool disposing)
    {
      this.F11.Dispose();
      this.F5.Dispose();
      base.Dispose(disposing);
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Color P16
    {
      get => base.BackColor;
      set => base.BackColor = Color.Transparent;
    }

    [Browsable(false)]
    [Obsolete("BackgroundImageLayout is not implemented.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ImageLayout P17
    {
      get => base.BackgroundImageLayout;
      set => throw new NotImplementedException("BackgroundImageLayout is not implemented.");
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [Obsolete("BackgroundImage is not implemented.", true)]
    public Image P18
    {
      get => (Image) null;
      set => throw new NotImplementedException("BackgroundImage is not implemented.");
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [Obsolete("TabStop is not implemented.", true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool P19
    {
      get => false;
      set => throw new NotImplementedException("TabStop is not implemented.");
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Obsolete("TabIndex is not implemented.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public int P20
    {
      get => base.TabIndex;
      set => throw new NotImplementedException("TabIndex is not implemented.");
    }

    public enum T34
    {
      F120,
      F121,
      F122,
      F123,
    }

    public enum T35
    {
      F124,
      F125,
      F126,
    }

    public enum T36
    {
      F127,
      F128,
    }
  }
}
