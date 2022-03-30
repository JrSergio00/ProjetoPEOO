using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;

class Arquivo<T>{
    public T Abrir(string Arquivo){
        XmlSerializer xml = new XmlSerializer(typeof(T));
        StreamReader f = new StreamReader(Arquivo, Encoding.Default);
        T x = (T) xml.Deserialize(f);
        f.Close();
        return x;
    }
    public void Salvar(string Arquivo, T x){
        XmlSerializer xml = new XmlSerializer(typeof(T));
        StreamWriter f = new StreamWriter(Arquivo, false, Encoding.Default);
        xml.Serialize(f , x);
        f.Close();
    }

}