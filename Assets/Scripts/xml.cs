using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;


public class xml : MonoBehaviour {
    public Transform steel;

    void Start ()
    {
        List<Vector3> list=translateTileMapToList ();

        addListToWin (list);
    }

    List<Vector3> translateTileMapToList()
    {
        List<Vector3> list = new List<Vector3> ();


        XmlDocument xmlDoc = new XmlDocument ();
		xmlDoc.Load ("Assets/Resources/test1.tmx");
        XmlNode mapNode = xmlDoc.SelectSingleNode ("map");

        // map 
        foreach (XmlNode layerNode in mapNode.ChildNodes) 
        {


            //tileset layer

            if (layerNode.Name == "layer") 
            {
                XmlElement layerElement = (XmlElement)layerNode;
                string widthString = layerElement.GetAttribute ("width");
				int width = System.Int32.Parse (widthString);
                string heightString = layerElement.GetAttribute ("height");
				int height = System.Int32.Parse (heightString);
                //string height =(int) layerElement.GetAttribute ("height").ToString();

                //data
                foreach (XmlNode dataNode in ((XmlElement)layerNode).ChildNodes) 
                {
                    //tile
                    int number=0;
                    foreach (XmlNode tileNode in ((XmlElement)dataNode).ChildNodes)
                    {
                        XmlElement tileElement = (XmlElement)tileNode;
                        int x = number % width;
                        int y = height - number / height;

                        string zString = tileElement.GetAttribute ("gid");
						int z = System.Int32.Parse (zString);

                        list.Add (new Vector3 (x, y, z));


                        number++;

                    }
                }
            }
        }
        return list;
    }


    void addListToWin (List<Vector3> list)
    {

        for (int i = 0; i < list.Count; i++)
        {
            if (list [i].z == 11) {
                Instantiate (steel, new Vector3 (list[i].x * 32f / 100f, list[i].y * 32f / 100f, 0), Quaternion.identity);
            }
        }

    }


}