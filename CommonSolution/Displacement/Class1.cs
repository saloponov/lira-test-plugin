using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using LiraAPI;
using FEModel;
using FEModel.Interfaces;
using FEGeometry;
using System.Windows.Forms;

namespace LiraDisplacement
{
    public class GetLiraModel : ILiraPrimeAPI
    {
        //private int indexGroupsUnionDOFNodeContainer = 0;
        //private IGroupsUnionDOFNodeContainer groupsUnionDOFNodeContainer; // массив групп объединения перемещений
        public ReturnCodes ExecuteProgram_Prime(IModelAPI pModelAPI, Results_Key pCurentCase)
        {
            IModel imodel = pModelAPI as IModel;
            if (imodel == null) // модель не определена
                return ReturnCodes.RC_IGNOR;

            // иначе выполняем код
            List<INode> listNode = new List<INode>();// массив элементов с оригинальной модели для синхронизации

            imodel = pModelAPI as IModel;
            int nodeCount = 0;
            if (0 < imodel.getAllElementNumber()) // проверяем наличие хотя бы одного элемента в модели
            {
                do // формируем список элементов
                {
                    INode ielement = imodel.getAllNode(nodeCount);
                    if (ielement.getFlag(INode.e_NdFlag.ENF_Selected)) //узел выделен.
                    {
                        listNode.Add(ielement);
                    }
                    ++nodeCount;
                }
                while (nodeCount < imodel.getAllNodeNumber());
            }

            //сортируем список по координатам
            if (listNode.Count > 1 & listNode.Count%2==0) //проверка на четность и количество узлов чтобы больше 2х было
            {
                List<Node3DIndex> listNode3D = new List<Node3DIndex>(); //создаем список узлов для упрощения работы
                for (int i = 0; i < listNode.Count; i++)
                {
                    Node3DIndex node3DIndex = new Node3DIndex(listNode[i].getIndex());
                    node3DIndex.x = listNode[i].getX();
                    node3DIndex.y = listNode[i].getY();
                    node3DIndex.z = listNode[i].getZ();
                    listNode3D.Add(node3DIndex);
                }
                var listNode3dSort = listNode3D.OrderBy(x => x.x).ThenBy(y => y.y).ThenBy(z => z.z).ToList();

                List<NodeToNode> listNodeToNode= new List<NodeToNode>();
                for (int i = 0; i < listNode3dSort.Count; i++) //вычисляем длину и находим сопоставления по самому короткому расстоянию
                {
                    NodeToNode nodeToNode=new NodeToNode();
                    int bufIndex = listNode3dSort[i].indexNode;
                    double bufLength=1e8;
                    nodeToNode.indexNode1 = bufIndex;
                    Node3DIndex startNode3DIndex = listNode3dSort[i];
                    int delIndex = i + 1;
                    for (int j = i+1; j < listNode3dSort.Count; j++)
                    {
                        Node3DIndex bufNode3DIndex = listNode3dSort[j];
                        double length = Math.Pow((Math.Pow((startNode3DIndex.x - bufNode3DIndex.x),2) + Math.Pow((startNode3DIndex.y - bufNode3DIndex.y), 2)+ Math.Pow((startNode3DIndex.z - bufNode3DIndex.z), 2)),0.5);
                        if(length < bufLength)
                        {
                            bufLength = length;
                            bufIndex = listNode3dSort[j].indexNode;
                            delIndex = j;
                        }
                    }
                    nodeToNode.indexNode2 = bufIndex;
                    listNode3dSort.RemoveAt(delIndex);
                    listNodeToNode.Add(nodeToNode);
                }

                //открываем форму с выбором типа объединений
                CheckDisp checkDisp = new CheckDisp();
                checkDisp.ShowDialog();

                IGroupsUnionDOFNodeContainer groupsUnionDOFNodeContainer=imodel.getGroupsUnionDOFNodeContainer(); // массив групп объединения перемещений
                GroupsUnionDOFNode groupsUnion = new GroupsUnionDOFNode(groupsUnionDOFNodeContainer);
                int indexDOFgroups = 0;
                    for (int i = 0; i < listNodeToNode.Count; i++)
                    {
                        groupsUnion.Add_UnionDOFNode(indexDOFgroups, listNodeToNode[i].indexNode1);
                        groupsUnion.Add_UnionDOFNode(indexDOFgroups, listNodeToNode[i].indexNode2);
                        indexDOFgroups++;
                    }

                    groupsUnion.put_Direction((e_Direction)checkDisp.intDir);
                    groupsUnionDOFNodeContainer.addGroupUnionDOFNode(groupsUnion);               
            }
            else
            {
                MessageBox.Show("В модели должно быть выбрано не менее 2х узлов. Количество узов должно быть четным.");
            }


            return ReturnCodes.RC_OK;
        }
    }

    public class NodeToNode
    {
        public int indexNode1 { get; set; }
        public int indexNode2 { get; set; }

    }

    public class Node3DIndex:Node3D
    {
        public int indexNode { get; set;}

        public Node3DIndex()
        {

        }
        public Node3DIndex(int index)
        {
            indexNode = index;
        }
    }
}
