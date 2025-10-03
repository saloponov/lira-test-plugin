using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LiraAPI;
using FEModel;
using FEModel.Interfaces;
using FEGeometry;
using FEModel.Node;

namespace LiraSplit
{
    public class GetLiraModel : ILiraPrimeAPI
    {
        public ReturnCodes ExecuteProgram_Prime(IModelAPI pModelAPI, Results_Key pCurentCase)
        {
            IModel imodel = pModelAPI as IModel;
            if (imodel == null) // модель не определена
                return ReturnCodes.RC_IGNOR;

            // иначе выполняем код
            List<IElement> listElementOrig = new List<IElement>();// массив элементов с оригинальной модели для синхронизации

            imodel = pModelAPI as IModel;
            List<string> description = new List<string>();
            int elementsCount = 0;
            if (0 < imodel.getAllElementNumber()) // проверяем наличие хотя бы одного элемента в модели
            {
                do // формируем список элементов
                {
                    IElement ielement = imodel.getAllElement(elementsCount);
                    if (ielement.getFlag(IElement.e_ElFlag.EEF_Selected)) //элемент выделен.
                    {
                        listElementOrig.Add(ielement);
                    }
                    ++elementsCount;
                }
                while (elementsCount < imodel.getAllElementNumber());
            }
            
            if(listElementOrig.Count==2) //выбрано 2 элемента
            {
                List<INode> listNodes = new List<INode>();
                List<int> indexElement = new List<int>();
                for (int i = 0; i < listElementOrig.Count; i++) //Считываем узлы
                {
                    if (listElementOrig[i].getNodeNumber() == 2) // элемент стержневой
                    {
                        INode nodeStart = listElementOrig[i].getNodePtr(0);
                        INode nodeEnd = listElementOrig[i].getNodePtr(1);
                        listNodes.Add(nodeStart);
                        listNodes.Add(nodeEnd);
                    }
                    //indexElement.Add(listElementOrig[i].getIndex());
                }
                //Проверяем на параллельность
                double znamenatel=(listNodes[0].getX()- listNodes[1].getX())*(listNodes[2].getY()- listNodes[3].getY())-(listNodes[0].getY() - listNodes[1].getY()) * (listNodes[2].getX() - listNodes[3].getX());
                double X;
                double Y;
                //double Z;
                List<double> listZ=new List<double>();
                listZ.Add(listNodes[0].getZ());
                listZ.Add(listNodes[1].getZ());
                listZ.Add(listNodes[2].getZ());
                listZ.Add(listNodes[3].getZ());
                listZ.Sort();
                if (znamenatel!=0.000000001|| znamenatel != 0.0) // не параллельны
                {
                    //вычисляем координаты проекции точки пересечения на плоскость Z=0
                    double chislitelX = (listNodes[0].getX()* listNodes[1].getY() - listNodes[0].getY()* listNodes[1].getX()) * (listNodes[2].getX() - listNodes[3].getX()) - (listNodes[0].getX() - listNodes[1].getX()) * (listNodes[2].getX() * listNodes[3].getY() - listNodes[2].getY() * listNodes[3].getX());
                    double chislitelY = (listNodes[0].getX() * listNodes[1].getY() - listNodes[0].getY() * listNodes[1].getX()) * (listNodes[2].getY() - listNodes[3].getY()) - (listNodes[0].getY() - listNodes[1].getY()) * (listNodes[2].getX() * listNodes[3].getY() - listNodes[2].getY() * listNodes[3].getX());
                    X = chislitelX / znamenatel;
                    Y = chislitelY / znamenatel;
                    // ищем точки пересечения 
                    segmentGr3D line1 = new segmentGr3D(listNodes[0].getX(), listNodes[0].getY(), listNodes[0].getZ(), listNodes[1].getX(), listNodes[1].getY(), listNodes[1].getZ());
                    segmentGr3D line2 = new segmentGr3D(listNodes[2].getX(), listNodes[2].getY(), listNodes[2].getZ(), listNodes[3].getX(), listNodes[3].getY(), listNodes[3].getZ());
                    segmentGr3D lineSection = new segmentGr3D(X, Y, listZ[0], X, Y, listZ[3]);
                    nodeGr3D node1= Geometry3D.CrossLines(line1, lineSection);
                    nodeGr3D node2 = Geometry3D.CrossLines(line2, lineSection);
                    //Добавляем в модель узлы найденных точек пересечения
                    CNode n1=new CNode(imodel, node1.x, node1.y, node1.z);
                    CNode n2 = new CNode(imodel, node2.x, node2.y, node2.z);
                    imodel.addNode(n1);
                    imodel.addNode(n2);
                    //снимаем выбор с КЭ
                    listElementOrig[0].delFlag(IElement.e_ElFlag.EEF_Selected);
                    listElementOrig[1].delFlag(IElement.e_ElFlag.EEF_Selected);
                }
                else
                {
                    MessageBox.Show("Прямые параллельны");
                }
                
            }
            else
            {
                MessageBox.Show("Выбрать не более 2х элементов");
            }
            return ReturnCodes.RC_OK;
        }

    }
}
