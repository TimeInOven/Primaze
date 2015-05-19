using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;

namespace CompactMovieManager
{
    public class XMLManager
    {
        /// <summary> 
        /// Write a setting to an XML settings file. 
        /// </summary> 
        /// <param name="p_strFile">The XML settings file.</param> 
        /// <param name="p_strNodeStructure">The XML XPath to traverse.</param> 
        /// <param name="p_strAttribute">The attribute name of the final XML node element.</param> 
        /// <param name="p_Value">The settings value to write.</param> 
        public static void WriteSetting(string p_strFile, string p_strNodeStructure,
                                        string p_strAttribute, string p_Value)
        {
            if (p_strFile != "")
            {
                if ((p_strNodeStructure != "") && (p_strAttribute != ""))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    bool bFileExists = File.Exists(p_strFile);
                    string[] aNodes = p_strNodeStructure.Split('/');
                    string strMessage = "";

                    try
                    {
                        XmlNode xmlLastNode = null;

                        if (bFileExists)
                        {
                            xmlDoc.Load(p_strFile);
                        }

                        #region Add nodes if needed
                        try
                        {
                            foreach (string strNode in aNodes)
                            {
                                //first element ... 
                                if (xmlLastNode == null)
                                {
                                    xmlLastNode = xmlDoc.SelectSingleNode(strNode);
                                    if (xmlLastNode == null)
                                    {
                                        xmlLastNode = xmlDoc.AppendChild(xmlDoc.CreateElement(strNode));
                                    }
                                }
                                else
                                {
                                    XmlNode xmlTempNode = xmlLastNode.SelectSingleNode(strNode);

                                    if (xmlTempNode != null)
                                    {
                                        xmlLastNode = xmlTempNode;
                                    }
                                    else
                                    {
                                        xmlTempNode = xmlDoc.CreateElement(strNode);
                                        xmlLastNode = xmlLastNode.AppendChild(xmlTempNode);
                                    }
                                }
                            }
                        }
                        catch (XmlException xmlEx)
                        {
                            xmlLastNode = null;
                            strMessage = xmlEx.Message;
                        }
                        catch (Exception ex)
                        {
                            xmlLastNode = null;
                            strMessage = ex.Message;
                        }
                        #endregion

                        if (xmlLastNode != null)
                        {
                            #region insert attribute value
                            if (xmlLastNode.Attributes[p_strAttribute] == null)
                            {
                                xmlLastNode.Attributes.Append(xmlDoc.CreateAttribute(p_strAttribute));
                            }
                            xmlLastNode.Attributes[p_strAttribute].Value = p_Value;
                            #endregion
                        }
                        else
                        {
                            throw new Exception(strMessage);
                        }

                        xmlDoc.Save(p_strFile);
                    }
                    catch (XmlException xmlEx)
                    {
                        throw xmlEx;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    throw new Exception("XML node structure or attribute not specified.");
                }
            }
            else
            {
                throw new Exception("XML settings file not specified.");
            }
        }

        protected static string _ReadSetting(string p_strFile, string p_strNodeStructure,
                                            string p_strAttribute, ref string p_ErrorMessage)
        {
            if (p_strFile != "")
            {
                if (File.Exists(p_strFile))
                {
                    if ((p_strNodeStructure != "") && (p_strAttribute != ""))
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        string[] aNodes = p_strNodeStructure.Split('/');

                        try
                        {
                            xmlDoc.Load(p_strFile);

                            XmlNode xmlLastNode = null;
                            foreach (string strNode in aNodes)
                            {
                                if (xmlLastNode == null)
                                {
                                    xmlLastNode = xmlDoc.SelectSingleNode(strNode);
                                }
                                else
                                {
                                    xmlLastNode = xmlLastNode.SelectSingleNode(strNode);
                                }
                            }

                            if (xmlLastNode != null)
                            {
                                if (xmlLastNode.Attributes[p_strAttribute] != null)
                                {
                                    return xmlLastNode.Attributes[p_strAttribute].Value;
                                }
                                else
                                {
                                    throw new Exception("Attribute: [" + p_strAttribute + "] not found.");
                                }
                            }
                            else
                            {
                                throw new Exception("One of the nodes in the XML XPath was not found.");
                            }
                        }
                        catch (XmlException xmlEx)
                        {
                            p_ErrorMessage = xmlEx.Message;
                            return null;
                        }
                        catch (Exception ex)
                        {
                            p_ErrorMessage = ex.Message;
                            return null;
                        }
                        finally
                        {
                            xmlDoc = null;
                        }
                    }
                    else
                    {
                        p_ErrorMessage = "XML node structure or attribute not specified.";
                        return null;
                    }
                }
                else
                {
                    p_ErrorMessage = "XML settings file does not exist:\n[" + p_strFile + "]";
                    return null;
                }
            }
            else
            {
                p_ErrorMessage = "XML settings file not specified.";
                return null;
            }
        }

        /// <summary> 
        /// Reads and returns a setting from an XML file. 
        /// </summary> 
        /// <param name="p_strFile">The XML settings file.</param> 
        /// <param name="p_strNodeStructure">The XML XPath to traverse.</param> 
        /// <param name="p_strAttribute">The attribute of the final XML node element.</param> 
        /// <returns>Return the specified setting value, or null if an error occurrs.</returns> 
        public static string ReadSetting(string p_strFile, string p_strNodeStructure,
                                            string p_strAttribute)
        {
            string strErrorMessage = "";

            return _ReadSetting(p_strFile, p_strNodeStructure,
                                    p_strAttribute, ref strErrorMessage);
        }

        /// <summary> 
        /// Reads and returns a setting from an XML file. 
        /// </summary> 
        /// <param name="p_strFile">The XML settings file.</param> 
        /// <param name="p_strNodeStructure">The XML XPath to traverse.</param> 
        /// <param name="p_strAttribute">The attribute of the final XML node element.</param> 
        /// <param name="p_strMessage">The string where to store any error message generated by the method.</param> 
        /// <returns>Return the specified setting value, or null if an error occurrs.</returns>       
        public static string ReadSetting(string p_strFile, string p_strNodeStructure,
                                    string p_strAttribute, ref string p_strMessage)
        {
            return _ReadSetting(p_strFile, p_strNodeStructure,
                                    p_strAttribute, ref p_strMessage);
        }

    }
}