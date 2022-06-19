using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Newtonsoft.Json;

namespace CorpusDraftCSharp
{
    [Serializable]
    public class Clause : ICorpusUnit
    {


        #region objectValues
        [JsonProperty]
        public string documentID { get; set; }
        [JsonProperty]
        public string filePath { get; set; }
        [JsonProperty]
        public string textID { get; set; }
        [JsonProperty]
        public List<Dictionary<string, List<Value>>> tagging { get; set; }
        [JsonProperty]
        public string Id { get; set; }
        [JsonProperty]
        public string text { get; set; }
        [JsonProperty]
        public List<Token> realizations = new List<Token>();
        #endregion


        #region Constructors
        [JsonConstructor]
        public Clause(string _documentID, string _textID, string _filePath, string _clauseID, string _clauseText, List<Dictionary<string, List<Value>>> _clauseFields, List<Token> _realizations)
        {
            this.documentID = _documentID;
            this.filePath = _filePath;
            this.textID = _textID;
            this.Id = _clauseID;
            this.text = _clauseText;
            this.tagging = _clauseFields;
            this.realizations = _realizations;
        }
        public Clause(string _documentID, string _textID, string _filePath, string _clauseID, string _clauseText)
        {
            this.documentID = _documentID;
            this.filePath = _filePath;
            this.textID = _textID;
            this.Id = _clauseID;
            this.text = _clauseText;
        }

        public Clause(Section text, string _clauseID, string _clauseText)
        {
            this.documentID = text.documentID;
            this.filePath = text.filePath;
            this.textID = text.Id;
            this.Id = _clauseID;
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
                foreach (var r in realizations.OrderBy(realization => Convert.ToInt32(realization.documentID)).ThenBy(realization => Convert.ToInt32(realization.textID)).ThenBy(realization => Convert.ToInt32(realization.clauseID)).ThenBy(realization => Convert.ToInt32(realization.Id)))
                {
                    collected += r.Output();
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
                return "<span title=\"" + clauseInRawText.Invoke(tagging) + "\" data-content=\"" + clauseInHTML.Invoke(tagging) + "\" class=\"clause\" id=\"" + this.documentID + "|" + this.textID + "|" + this.Id + "\"> " + tokens.Invoke() + "\t<button class=\"clauseButton\" type=\"button\">Добавить разметку</button></span><br />";
            }
            catch
            {
                return "<span title= \"\" data-content=\"\" class=\"clause\" id=\"" + this.documentID + "|" + this.Id  + "\"> " + tokens.Invoke() + "\t<button class=\"clauseButton\" type=\"button\">Добавить разметку</button></span><br />";
            }
        }
        public string Jsonize()
        {
            string jsonedClause = JsonConvert.SerializeObject(this, Formatting.Indented);
            return jsonedClause;
        }
        #endregion
    }
}
