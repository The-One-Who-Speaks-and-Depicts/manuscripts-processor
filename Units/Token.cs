using System;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;
using System.Linq;

namespace CorpusDraftCSharp
{
    [Serializable]
    public class Token : IEquatable<Token>, ICorpusUnit
    {

        #region objectValues
        [JsonProperty]
        public string documentID { get; set; }
        [JsonProperty]
        public string filePath { get; set; }
        [JsonProperty]
        public string textID { get; set; }
        [JsonProperty]
        public string clauseID { get; set; }
        [JsonProperty]
        public List<Dictionary<string, List<Value>>> tagging { get; set; }
        [JsonProperty]
        public string Id { get; set; }
        [JsonProperty]
        public string lexemeView { get; set; }
        [JsonProperty]
        public string text { get; set; }
        [JsonProperty]
        public List<Grapheme> letters { get; set; }
        #endregion

        #region Constructors

        [JsonConstructor]
        public Token(string _documentID, string _filePath, string _textID, string _clauseID, List<Dictionary<string, List<Value>>> _fields, string _realizationID, string _lexemeOne, string _lexemeTwo, List<Grapheme> _letters)
        {
            this.documentID = _documentID;
            this.filePath = _filePath;
            this.textID = _textID;
            this.clauseID = _clauseID;
            this.tagging = _fields;
            this.Id = _realizationID;
            this.lexemeView = _lexemeOne;
            this.text = _lexemeTwo;
            this.letters = _letters;
        }

        public Token(Clause clause, string _realizationID, string _lexemeOne, string _lexemeTwo)
        {
            this.documentID = clause.documentID;
            this.filePath = clause.filePath;
            this.textID = clause.textID;
            this.clauseID = clause.Id;
            this.Id = _realizationID;
            this.lexemeView =_lexemeOne;
            this.text = _lexemeTwo;
        }


        public Token(string _documentID, string _filePath, string _textID, string _clauseID, string _realizationID, string _lexemeOne, string _lexemeTwo)
        {
            this.documentID = _documentID;
            this.filePath = _filePath;
            this.textID = _textID;
            this.clauseID = _clauseID;
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
                foreach (var l in letters.OrderBy(graheme => Convert.ToInt32(graheme.documentID)).ThenBy(graheme => Convert.ToInt32(graheme.textID)).ThenBy(grapheme => Convert.ToInt32(grapheme.clauseID)).ThenBy(graheme => Convert.ToInt32(graheme.realizationID)).ThenBy(graheme => Convert.ToInt32(graheme.Id)))
                {
                    collected += l.Output();
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
                return "<span title=\"" + fieldsInRawText.Invoke(tagging) + "\" data-content=\"" + fieldsInHTML.Invoke(tagging) + "\" class=\"word\" id=\"" + this.documentID + "|" + this.textID + "|" + this.clauseID + "|" + this.Id + "\"> " + graphemes.Invoke() + "</span>";
            }
            catch
            {
                return "<span title= \"\" data-content=\"\" class=\"word\" id=\"" + this.documentID + "|" + this.textID +  "|" + this.clauseID + "|" + this.Id + "\"> " + graphemes.Invoke() + "</span>";
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
                return "<span title=\"" + fieldsInRawText.Invoke(tagging) + "\" data-content=\"" + fieldsInHTML.Invoke(tagging) + "\" class=\"word\" id=\"" + this.documentID + "|" + this.textID + "|" + this.clauseID + "|" + this.Id + "\"> " + this.text + "</span>";
            }
            catch
            {
                return "<span title= \"\" data-content=\"\" class=\"word\" id=\"" + this.documentID + "|" + this.textID + "|" + this.clauseID + "|" + this.Id + "\"> " + this.text + "</span>";
            }
        }

        public bool Equals(Token other)
        {
            if (documentID == other.documentID && textID == other.textID && clauseID == other.clauseID && Id == other.Id) return true;
            return false;
        }

        #endregion

        #region privateMethods
        #endregion

    }
}
