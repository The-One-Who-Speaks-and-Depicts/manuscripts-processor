using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Newtonsoft.Json;

namespace CorpusDraftCSharp
{
    [Serializable]
    public class Clause : IUnitGroup<IClausePart>, IComparable<Clause>
    {


        #region objectValues
        [JsonProperty]
        public string filePath { get; set; }
        [JsonProperty]
        public List<Dictionary<string, List<Value>>> tagging { get; set; }
        [JsonProperty]
        public string Id { get; set; }
        [JsonProperty]
        public string text { get; set; }
        [JsonProperty]
        public List<IClausePart> subunits { get; set; }
        #endregion


        #region Constructors
        [JsonConstructor]
        public Clause(string _filePath, string _clauseID, string _clauseText, List<Dictionary<string, List<Value>>> _clauseFields, List<IClausePart> _realizations)
        {
            this.filePath = _filePath;
            this.Id = _clauseID;
            this.text = _clauseText;
            this.tagging = _clauseFields;
            this.subunits = _realizations;
        }
        public Clause(string _filePath, string _clauseID, string _clauseText)
        {
            this.filePath = _filePath;
            this.Id = _clauseID;
            this.text = _clauseText;
        }

        public Clause(Section text, string _clauseID, string _clauseText)
        {
            this.Id = text.Id + "|" + _clauseID;
            this.filePath = text.filePath;
            this.text = _clauseText;
        }
        public Clause()
        {

        }

        #endregion

        #region publicMethods
        public string Output()
        {
            Func<string> tokens = () =>
            {
                string collected = "";
                var sortableSubunits = new List<IClausePart>();
                foreach (var unit in subunits)
                {
                    if (unit is Token)
                    {
                        sortableSubunits.Add(unit);
                    }
                    else
                    {
                        foreach (var atomicUnit in unit.subunits)
                        {
                            sortableSubunits.Add((IClausePart) atomicUnit);
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
                Func<List<Dictionary<string, List<Value>>>, string> clauseInRawText = (List<Dictionary<string, List<Value>>> fields) =>
                {
                    string result = "";
                    foreach (var optional_tagging in fields)
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
                    }
                    return result;
                };
                Func<List<Dictionary<string, List<Value>>>, string> clauseInHTML = (List<Dictionary<string, List<Value>>> fields) =>
                {
                    return clauseInRawText.Invoke(fields).Replace("\n", "<br />");
                };
                return "<span title=\"" + clauseInRawText.Invoke(tagging) + "\" data-content=\"" + clauseInHTML.Invoke(tagging) + "\" class=\"clause\" id=\"" + Id + "\"> " + tokens.Invoke() + "\t<button class=\"clauseButton\" type=\"button\">Добавить разметку</button></span><br />";
            }
            catch
            {
                return "<span title= \"\" data-content=\"\" class=\"clause\" id=\"" + Id + "\"> " + tokens.Invoke() + "\t<button class=\"clauseButton\" type=\"button\">Добавить разметку</button></span><br />";
            }
        }
        public string Jsonize()
        {
            string jsonedClause = JsonConvert.SerializeObject(this, Formatting.Indented);
            return jsonedClause;
        }

        public int CompareTo(Clause other)
        {
            return MyExtensions.CompareIds(Id, other.Id);
        }
        #endregion
    }
}
