using System;
using System.Collections;
using System.Text;
using OrbCreationExtensions;
using UnityEngine;

namespace YousicianAssignment.Interface
{
    public class ProgramInfo
    {
        public string ItemTitle { get; protected set; }
        
        public string Description { get; protected set; }
        public ArrayList CountryOfOrigin { get; protected set; }
        public ArrayList Creator { get; protected set; }
        
        public ArrayList Subjects { get; protected set; }
        
        public string Type { get; protected set; }

        private Hashtable table;
        
        public ProgramInfo(Hashtable table)
        {
            this.table = table;
            
            // Assign
            ItemTitle = (string)((Hashtable)this.table["title"])["fi"];
            Description = (string)((Hashtable)this.table["description"])["fi"];
            CountryOfOrigin = (ArrayList) (this.table["countryOfOrigin"]);
            Creator = (ArrayList) (this.table["creator"]);
            Subjects = (ArrayList) this.table["subject"];
            Type = (string) this.table["type"];
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            string output = "Title: " + ItemTitle;
            builder.AppendLine("Title: " + ItemTitle);
            builder.AppendLine();
            output = "Country of Origin: ";
            foreach (var country in CountryOfOrigin)
            {
                output += country + " ";
            }

            builder.AppendLine(output);
            builder.AppendLine();
            output = "Creator: ";
            string creators = string.Empty;
            if (Creator.Count > 0)
            {
                foreach (var creator in Creator)
                {
                    string current = (string)((Hashtable) creator)["name"];
                    creators += string.Format("{0} {1}", creators, current);
                }
            }

            output += creators;
            builder.AppendLine(output);
            builder.AppendLine();

            output = "Description: " + Description;
            builder.AppendLine(output);
            builder.AppendLine();

            output = "Subject: ";
            StringBuilder subjectsBuilder = new StringBuilder();
            foreach (var subject in Subjects)
            {
                string current = (string)((Hashtable) subject)["key"];
                if ( !string.IsNullOrEmpty(current) && !subjectsBuilder.ToString().Contains(current))
                {
                    subjectsBuilder.Append(current + ", ");
                }
            }

            builder.Append(output);
            builder.AppendLine(subjectsBuilder.ToString());
            builder.AppendLine();
            output = "Type: " + Type;
            builder.Append(output);

            return builder.ToString();
        }
    }
}