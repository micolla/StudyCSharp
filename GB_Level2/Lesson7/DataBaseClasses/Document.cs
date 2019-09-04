using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCard.DataBaseClasses
{
    struct Document:IEquatable<Document>
    {
        public enum DocumentTypes
        {
            Passport
            ,DriverLicense
        }
        public string Serial { get; private set; }
        public string Number { get; private set; }
        public DocumentTypes DocumentType { get; private set; }
        public Document(string serial,string number, DocumentTypes documentType)
        {
            this.Number = number;
            this.Serial = serial;
            this.DocumentType = documentType;
        }
        #region Вспомогательные функции
        public override bool Equals(object obj)
        {
            if (obj is Document)
                return this.Equals((Document)obj);
            else
                return false;
        }

        public bool Equals(Document other)
        {
            return this.DocumentType.Equals(other.DocumentType)
                    && this.Serial.Equals(other.Serial)
                    && this.Number.Equals(other.Number);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return this.DocumentType.ToString() + this.Number.ToString() + this.Serial.ToString();
        }
        public static bool operator ==(Document d, Document d2) => d.Equals(d2);
        public static bool operator !=(Document d, Document d2) => !d.Equals(d2);
        #endregion
    }
}
