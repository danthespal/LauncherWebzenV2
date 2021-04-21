using N1.N3.N5;
using System;
using System.Collections.Generic;
using System.Text;

namespace N1.N3.N4
{
    public class T12 : T13
    {
        private T16 F35;

        public T12() : this(new T16())
        {
        }

        public T12(T16 configuration) => this.P44 = configuration != null ? configuration : throw new ArgumentNullException(nameof (configuration));

        public virtual string IniDataToString(T6 iniData)
        {
          StringBuilder sb = new StringBuilder();
          if (this.P44.P58)
            this.M43(iniData.P28, sb);
          foreach (T10 section in iniData.P30)
            this.M42(section, sb);
          return sb.ToString();
        }

        public T16 P44
        {
          get => this.F35;
          set => this.F35 = value.M46();
        }
            public T16 P45 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            private void M42(T10 section, StringBuilder sb)
        {
          if (sb.Length > 0)
            sb.Append(this.P44.P55);
          sb.Append(string.Format("{0}{1}{2}{3}", (object) this.P44.P50, (object) section.P37, (object) this.P44.P51, (object) this.P44.P55));
          this.M43(section.P41, sb);
        }

        private void M43(T9 keyDataCollection, StringBuilder sb)
        {
          foreach (T8 keyData in keyDataCollection)
          {
            if (keyData.P32.Count > 0)
              sb.Append(this.P44.P55);
            this.M44(keyData.P32, sb);
            sb.Append(string.Format("{0}{3}{1}{3}{2}{4}", (object) keyData.P34, (object) this.P44.P56, (object) keyData.P33, (object) this.P44.P57, (object) this.P44.P55));
          }
        }

        private void M44(List<string> comments, StringBuilder sb)
        {
          foreach (string comment in comments)
            sb.Append(string.Format("{0}{1}{2}", (object) this.P44.P54, (object) comment, (object) this.P44.P55));
        }
    }
}
