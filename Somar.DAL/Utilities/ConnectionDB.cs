using System.Xml;

namespace Somar.DAL.Utilities
{

    public static class ConnectionDB
    {
        public static string xml_conn(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Config/Conexao");
            string proServer = "", proDatabase = "", proUser = "", proPassword = "";

            foreach (XmlNode node in nodeList)
            {
                proServer = node.SelectSingleNode("Server").InnerText;
                proDatabase = node.SelectSingleNode("Database").InnerText;
                proUser = node.SelectSingleNode("User").InnerText;
                proPassword = node.SelectSingleNode("Password").InnerText;
            }

            return ("Data Source = " + proServer + "; Database =" + proDatabase + "; User ID = " + proUser + ";Password = " + proPassword + ";Persist Security Info=True;");
        }

    }
}
