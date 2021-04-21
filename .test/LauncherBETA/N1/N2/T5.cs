using N1.N3;
using N1.N3.N5;
using N1.N7;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace N1.N2
{
    public class T5
    {
        private List<Exception> F18;
        private readonly List<string> F19 = new List<string>();
        private string F20;

        public T5() : this(new T16())
        {
        }

        public T5(T16 parserConfiguration)
        {
            this.P24 = parserConfiguration != null ? parserConfiguration : throw new ArgumentNullException(nameof (parserConfiguration));
            this.F18 = new List<Exception>();
        }

        public virtual T16 P24 { get; protected set; }

        public bool P25 => this.F18.Count > 0;

        public ReadOnlyCollection<Exception> P26 => this.F18.AsReadOnly();

        public T6 M11(string iniDataString)
        {
            T6 currentIniData = this.P24.P52 ? (T6) new T7() : new T6();
            currentIniData.P27 = this.P24.M46();
            T6 t6;
            if (string.IsNullOrEmpty(iniDataString))
            {
                t6 = currentIniData;
            }
            else
            {
                this.F18.Clear();
                this.F19.Clear();
                this.F20 = (string) null;
                try
                {
                    string[] strArray = iniDataString.Split(new string[2]
                    {
                        "\n",
                        "\r\n"
                    }, StringSplitOptions.None);
                    for (int index = 0; index < strArray.Length; ++index)
                    {
                        string str = strArray[index];
                        if (!(str.Trim() == string.Empty))
                        {
                            try
                            {
                                this.ProcessLine(str, currentIniData);
                            }
                            catch (Exception ex)
                            {
                                T18 t18 = new T18(ex.Message, index + 1, str, ex);
                                if (this.P24.P62)
                                    throw t18;
                                this.F18.Add((Exception) t18);
                            }
                        }
                    }
                    if (this.F19.Count > 0)
                    {
                        if (currentIniData.P30.P42 <= 0 && currentIniData.P28.P36 > 0)
                            currentIniData.P28.M30().P32.AddRange((IEnumerable<string>) this.F19);
                        this.F19.Clear();
                    }
                }
                catch (Exception ex)
                {
                    this.F18.Add(ex);
                    if (this.P24.P62)
                        throw;
                }
                t6 = !this.P25 ? (T6) currentIniData.Clone() : (T6) null;
            }
            return t6;
        }

        protected virtual bool LineContainsAComment(string line) => !string.IsNullOrEmpty(line) && this.P24.P48.Match(line).Success;

        protected virtual bool LineMatchesASection(string line) => !string.IsNullOrEmpty(line) && this.P24.P49.Match(line).Success;

        protected virtual bool LineMatchesAKeyValuePair(string line) => !string.IsNullOrEmpty(line) && line.Contains(this.P24.P56.ToString());

        protected virtual string ExtractComment(string line)
        {
            string oldValue = this.P24.P48.Match(line).Value.Trim();
            this.F19.Add(oldValue.Substring(1, oldValue.Length - 1));
            return line.Replace(oldValue, "").Trim();
        }

        protected virtual void ProcessLine(string currentLine, T6 currentIniData)
        {
            currentLine = currentLine.Trim();
            if (this.LineContainsAComment(currentLine))
                currentLine = this.ExtractComment(currentLine);
            if (currentLine == string.Empty)
                return;
            if (this.LineMatchesASection(currentLine))
                this.ProcessSection(currentLine, currentIniData);
            else if (this.LineMatchesAKeyValuePair(currentLine))
                this.ProcessKeyValuePair(currentLine, currentIniData);
            else if (!this.P24.P65)
                throw new T18("Unknown file format. Couldn't parse the line: '" + currentLine + "'.");
        }

        protected virtual void ProcessSection(string line, T6 currentIniData)
        {
            string str = this.P24.P49.Match(line).Value.Trim();
            string keyName = str.Substring(1, str.Length - 2).Trim();
            this.F20 = !(keyName == string.Empty) ? keyName : throw new T18("Section name is empty");
            if (currentIniData.P30.M37(keyName))
            {
                if (!this.P24.P63)
                    throw new T18(string.Format("Duplicate section with name '{0}' on line '{1}'", (object) keyName, (object) line));
            }
            else
            {
                currentIniData.P30.M34(keyName);
                this.F19.Clear();
            }
        }

        protected virtual void ProcessKeyValuePair(string line, T6 currentIniData)
        {
            string key = this.ExtractKey(line);
            if ((!string.IsNullOrEmpty(key) ? 0 : (this.P24.P65 ? 1 : 0)) != 0)
                return;
            string str = this.ExtractValue(line);
            if (string.IsNullOrEmpty(this.F20))
            {
                if (!this.P24.P58)
                    throw new T18("key value pairs must be enclosed in a section");
                this.M12(key, str, currentIniData.P28, "global");
            }
            else
            {
                T10 t10 = currentIniData.P30.M38(this.F20);
                this.M12(key, str, t10.P41, this.F20);
            }
        }

        protected virtual string ExtractKey(string s)
        {
            int length = s.IndexOf(this.P24.P56, 0);
            return s.Substring(0, length).Trim();
        }

        protected virtual string ExtractValue(string s)
        {
            int num = s.IndexOf(this.P24.P56, 0);
            return s.Substring(num + 1, s.Length - num - 1).Trim();
        }

        protected virtual void HandleDuplicatedKeyInCollection(string key, string value, T9 keyDataCollection, string sectionName)
        {
            if (!this.P24.P59)
                throw new T18(string.Format("Duplicated key '{0}' found in section '{1}", (object) key, (object) sectionName));
            if (!this.P24.P60)
                return;
            keyDataCollection.set_Item(key, value);
        }

        private void M12(string key, string value, T9 keyDataCollection, string sectionName)
        {
            if (keyDataCollection.M24(key))
                this.HandleDuplicatedKeyInCollection(key, value, keyDataCollection, sectionName);
            else
                keyDataCollection.M22(key, value);
            keyDataCollection.M25(key).P32 = this.F19;
            this.F19.Clear();
        }
    }
}
