using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCard.DataBaseClasses
{
    class Document
    {
        public enum DocumentType
        {
            Passport
            ,DriverLicense
        }
        public string Serial { get; private set; }
        public string Number { get; private set; }
        public DocumentType documentType { get; private set; }
        public Document(string serial,string number,DocumentType documentType)
        {
            this.Number = number;
            this.Serial = serial;
            this.documentType = documentType;
        }
        public override bool Equals(object obj)
        {
            if (obj is Document&&this.documentType.Equals((obj as Document).documentType)
                    && this.Serial.Equals((obj as Document).Serial)
                    && this.Number.Equals((obj as Document).Number))
                return true;
            else
                return false;
        }
        public static bool operator ==(Document d, Document d2) => d.Equals(d2);
        public static bool operator !=(Document d, Document d2) => !d.Equals(d2);
    }
}
