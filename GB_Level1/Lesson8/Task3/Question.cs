using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
namespace BelieveOrNotBelieve
{

    // Класс для вопроса    
    [Serializable]
    public class Question
    {
        private string _text;   
        private bool _trueFalse;
        public bool trueFalse { get {return _trueFalse; } set { _trueFalse = value; } }
        public string text { get { return _text; } set { _text = value; } }
        public Question()
        {
        }
        public Question(string text, bool trueFalse)
        {
            this._text = text;
            this._trueFalse = trueFalse;
        }
    }
    
    class TrueFalse
    {
        public delegate void MethodContainer();
        /// <summary>
        /// Событие при добавлении первого элемента в список вопросов
        /// </summary>
        public event MethodContainer onFirstAddQuestion;
        /// <summary>
        /// Событие при удалении всех элементов списка вопросов
        /// </summary>
        public event MethodContainer onEmptyQuestion; 
        string _fileName;
        List<Question> _list;
        public string FileName
        {
            set { _fileName = value; }
        }
        public TrueFalse(string fileName)
        {
            this._fileName = fileName;
            _list = new List<Question>();
        }
        public void Add(string text, bool trueFalse)
        {
            _list.Add(new Question(text, trueFalse));
            if (_list.Count == 1)
            {
                onFirstAddQuestion();
            }
        }
        /// <summary>
        /// При удалении последнего элемента вызывает событие onEmptyQuestion
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            if (_list != null && index <= _list.Count && index >= 0) _list.RemoveAt(index);
            if (_list.Count == 0)
                onEmptyQuestion();//Событие обнуления списка
        }
        // Индексатор - свойство для доступа к закрытому объекту
        public Question this[int index]
        {
            get { return _list[index]; }
        }
        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(_fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, _list);
            fStream.Close();
        }
        public void Save(string filePath)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, _list);
            fStream.Close();
            this._fileName = filePath;
        }

        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
            try
            {
                _list = (List<Question>)xmlFormat.Deserialize(fStream);
                onFirstAddQuestion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                fStream.Close();
            }            
        }
        public int Count
        {
            get { return _list.Count; }
        }
    }
}
