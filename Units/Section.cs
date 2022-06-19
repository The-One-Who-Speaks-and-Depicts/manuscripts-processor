using System;
using System.Data;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace CorpusDraftCSharp
{
    [Serializable]
    public class Section : ICorpusUnit, IComparable<Section>
    {


	    #region objectValues
        [JsonProperty]
        public string filePath { get; set; }
        [JsonProperty]
        public string Id { get; set; }
        [JsonProperty]
        public string text { get; set; }
        [JsonProperty]
	    public List<Dictionary<string, List<Value>>> tagging { get; set; }
        [JsonProperty]
        public List<Clause> clauses = new List<Clause>();
        #endregion

        #region Constructors

        [JsonConstructor]
        public Section(string _textID, string _textName, string _filePath, List<Dictionary<string, List<Value>>> _textMetaData, List<Clause> _clauses)
        {
            this.Id = _textID;
            this.filePath = _filePath;
            this.text = _textName;
            this.tagging = _textMetaData;
            this.clauses = _clauses;
        }

        public Section(string _textID, string _textName, string _filePath)
        {
            this.Id = _textID;
            this.text = _textName;
            this.filePath = _filePath;
        }

        public Section(Manuscript document, string _textID, string _textName)
        {
            this.Id = document.Id + "|" + _textID;
            this.text = _textName;
            this.filePath = document.filePath;
        }

        public Section()
        {

        }


	#endregion



    #region PublicMethods
        public string Jsonize()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            return json;
        }

        public string Output()
        {
            Func<string> sentences = () =>
            {
                string collected = "";
                clauses.Sort();
                foreach (var c in clauses)
                {
                    collected += c.Output();
                }
                return collected;
            };
            try
            {
                Func<List<Dictionary<string, List<Value>>>, string> textInRawText = (List<Dictionary<string, List<Value>>> fields) =>
                {
                    string result = "";
                    foreach (var optional_tagging in fields)
                    {
                        foreach (var field in optional_tagging)
                        {
                            result += field.Key;
                            result += ":";
                            foreach (var fieldValue in field.Value)
                            {
                                result += fieldValue.name;
                                result += ";";
                            }
                            result += "||";
                        }
                        result += "\n";
                    }
                    return result;
                };
                Func<List<Dictionary<string, List<Value>>>, string> textInHTML = (List<Dictionary<string, List<Value>>> fields) =>
                {
                    return textInRawText.Invoke(fields).Replace("\n", "<br />");
                };
                return "<span title=\"" + textInRawText.Invoke(tagging) + "\" data-content=\"" + textInHTML.Invoke(tagging) + "\" class=\"text\" id=\"" + Id + "\"> " + sentences.Invoke() + "</span><br />";
            }
            catch
            {
                return "<span title= \"\" data-content=\"\" class=\"text\" id=\"" + Id + "\"> " + sentences.Invoke() + "</span><br />";
            }
        }

        public int CompareTo(Section other)
        {
            return MyExtensions.CompareIds(Id, other.Id);
        }

        #endregion
    }
}
