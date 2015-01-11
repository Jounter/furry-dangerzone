using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace ePubApp
{
    public class MyXMLHandler
    {
            String _xmlFilePath;
            String _xsdFilePath;

            bool _isValid;
            String _validateMessage;

            public MyXMLHandler(String xmlFile, String xsdFile)
            {
                _xmlFilePath = xmlFile;
                _xsdFilePath = xsdFile;
            }

            public String ValidateMessage
            {
                get { return _validateMessage; }
            }
            public bool ValidateXML()
            {
                _isValid = true;
                _validateMessage = "DocumentValid";
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(_xmlFilePath);
                    ValidationEventHandler eventXml = new ValidationEventHandler(MyValidateEvent);
                    doc.Schemas.Add(null, _xsdFilePath);
                    doc.Validate(eventXml);
                }
                catch (XmlException ex)
                {
                    _isValid = false;
                    _validateMessage = String.Format("[Error:]{0}", ex.Message);
                }
                return _isValid;
            }
            private void MyValidateEvent(Object sender, ValidationEventArgs args)
            {
                _isValid = false;
                //personalizar msg erro
                switch (args.Severity)
                {
                    case XmlSeverityType.Error:
                        _validateMessage = String.Format("[Error:] {0}", args.Message);
                        break;
                    case XmlSeverityType.Warning:
                        _validateMessage = String.Format("[Warning:] {0}", args.Message);
                        break;
                }
            }
        }
    
}
