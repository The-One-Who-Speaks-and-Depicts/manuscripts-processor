using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CorpusDraftCSharp
{
    [Serializable]
    public class Token : IUnitGroup<ITokenPart>, IEquatable<Token>, IComparable<Token>
    {

        #region objectValues
        [JsonProperty]
        public string filePath { get; set; }
        [JsonProperty]
        public List<Dictionary<string, List<Value>>> tagging { get; set; }
        [JsonProperty]
        public string Id { get; set; }
        [JsonProperty]
        public string lexemeView { get; set; }
        [JsonProperty]
        public string text { get; set; }
        [JsonProperty]
        public List<ITokenPart> subunits { get; set; }
        #endregion

        #region Constructors

        [JsonConstructor]
        public Token(string _filePath, List<Dictionary<string, List<Value>>> _fields, string _realizationID, string _lexemeOne, string _lexemeTwo, List<ITokenPart> _letters)
        {
            this.filePath = _filePath;
            this.tagging = _fields;
            this.Id = _realizationID;
            this.lexemeView = _lexemeOne;
            this.text = _lexemeTwo;
            this.subunits = _letters;
        }

        public Token(Clause clause, string _realizationID, string _lexemeOne, string _lexemeTwo)
        {
            this.filePath = clause.filePath;
            this.Id = clause.Id + "|" +_realizationID;
            this.lexemeView =_lexemeOne;
            this.text = _lexemeTwo;
        }


        public Token(string _filePath, string _realizationID, string _lexemeOne, string _lexemeTwo)
        {
            this.filePath = _filePath;
            this.Id = _realizationID;
            this.lexemeView = _lexemeOne;
            this.text = _lexemeTwo;
        }

        public Token()
        {

        }


        #endregion

        #region publicMethods

        public string Jsonize()
        {
            string realizationToJson = JsonConvert.SerializeObject(this, Formatting.Indented);
            return realizationToJson;
        }

        public string Output()
        {
            Func<string> graphemes = () =>
            {
                string collected = "";
                var sortableSubunits = new List<ITokenPart>();
                foreach (var unit in subunits)
                {
                    if (unit is Grapheme)
                    {
                        sortableSubunits.Add(unit);
                    }
                    else
                    {
                        foreach (var atomicUnit in unit.subunits)
                        {
                            sortableSubunits.Add((ITokenPart) atomicUnit);
                        }
                    }
                }
                sortableSubunits.Sort();
                foreach (var t in sortableSubunits)
                {
                    collected += t.Output();
                }
                return collected;
            };
            try
            {
                Func<List<Dictionary<string, List<Value>>>, string> fieldsInRawText = (List<Dictionary<string, List<Value>>> fields) =>
                {
                    string result = "";
                    foreach (var optional_tagging in fields)
                    {
                        if (optional_tagging.Count > 0)
                        {
                            foreach (var field in optional_tagging)
                            {
                                result += field.Key;
                                result += ":";
                                for (int i = 0; i < field.Value.Count; i++)
                                {
                                    result += field.Value[i].name;
                                    if (i < field.Value.Count - 1)
                                    {
                                        result += ",";
                                    }
                                }
                                result += ";\n";
                            }
                            result += "***";
                        }
                    }
                    return result;
                };
                Func<List<Dictionary<string, List<Value>>>, string> fieldsInHTML = (List<Dictionary<string, List<Value>>> fields) =>
                {
                    return fieldsInRawText.Invoke(fields).Replace("\n", "<br />");
                };
                return "<span title=\"" + fieldsInRawText.Invoke(tagging) + "\" data-content=\"" + fieldsInHTML.Invoke(tagging) + "\" class=\"word\" id=\"" + Id + "\"> " + graphemes.Invoke() + "</span>";
            }
            catch
            {
                return "<span title= \"\" data-content=\"\" class=\"word\" id=\"" + Id + "\"> " + graphemes.Invoke() + "</span>";
            }
        }

        public string KeyOutput()
        {
            try
            {
                Func<List<Dictionary<string, List<Value>>>, string> fieldsInRawText = (List<Dictionary<string, List<Value>>> fields) =>
                {
                    string result = "";
                    foreach (var optional_tagging in fields)
                    {
                        if (optional_tagging.Count > 0)
                        {
                            foreach (var field in optional_tagging)
                            {
                                result += field.Key;
                                result += ":";
                                for (int i = 0; i < field.Value.Count; i++)
                                {
                                    result += field.Value[i].name;
                                    if (i < field.Value.Count - 1)
                                    {
                                        result += ",";
                                    }
                                }
                                result += ";\n";
                            }
                            result += "***";
                        }
                    }
                    return result;
                };
                Func<List<Dictionary<string, List<Value>>>, string> fieldsInHTML = (List<Dictionary<string, List<Value>>> fields) =>
                {
                    return fieldsInRawText.Invoke(fields).Replace("\n", "<br />");
                };
                return "<span title=\"" + fieldsInRawText.Invoke(tagging) + "\" data-content=\"" + fieldsInHTML.Invoke(tagging) + "\" class=\"word\" id=\"" + Id + "\"> " + this.text + "</span>";
            }
            catch
            {
                return "<span title= \"\" data-content=\"\" class=\"word\" id=\"" + Id + "\"> " + this.text + "</span>";
            }
        }

        public bool Equals(Token other)
        {
            return Id == other.Id;
        }

        public int CompareTo(Token other)
        {
            return MyExtensions.CompareIds(Id, other.Id);
        }

        #endregion

        #region privateMethods
        #endregion

    }
}
