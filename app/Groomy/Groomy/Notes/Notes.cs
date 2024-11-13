using Groomy.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomy.Notes
{
    internal class Notes : IGenericObject
    {
        public string noteID;
        public string title;
        public string payload;
        public string createDate;

        public Dictionary<string, string> FilePaths = new Dictionary<string, string>
        {
            { "NotesData", "notes.json" }
        };
        public Notes(string t, string p, string cd, string nID)
        {
            this.noteID = nID;
            this.title = t;
            this.payload = p;
            this.createDate = cd;
        }
        public Notes(string t, string p, string cd) : this(t, p, cd, Helpers.RandomSHA256Hash())
        {
        }
        public Dictionary< string, Dictionary<string, string>> GetFields()
        {
            var temp = new Dictionary<string, Dictionary<string, string>>();
            temp["NotesData"] = new Dictionary<string, string>
                {
                    { "NoteID", noteID.ToString() },
                    { "Title", title.ToString() },
                    { "Payload", payload.ToString() },
                    { "CreateDate", createDate.ToString() }
                };
            return temp;
        }
        public string GetKey()
        {
            return noteID;
        }
        public Dictionary<string, string> GetDBFilePaths()
        {
            return FilePaths;
        }
    }
}
