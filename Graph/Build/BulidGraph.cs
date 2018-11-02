using System;
using System.Collections.Generic;

namespace Graph{

    /// <summary>
    /// 构建图有两种常用的方式：
    ///     <para>
    ///     1. 使用邻接矩阵的方式构建图,即用一个2维数组,
    ///     存储以a[i][j]的形式表示存储从点i到点j的距离
    ///     邻接矩阵主要用来表示顶点和顶点之间的关系.
    ///     顶点数量过多时,不适合使用邻接矩阵来存储图.
    ///     </para>
    ///     <para>
    ///     1. 邻接链表,也称为边链表. 顾名思义,用线性表存储图的顶点集合,用链表存储它的所有邻边
    ///     </para>
    /// </summary>
    public struct Graph<T> {

        /// <summary>
        /// 顶点数量
        /// </summary>
        private int vertexCount;

        /// <summary>
        /// 边的数量
        /// </summary>
        private int edgeCount;

        /// <summary>
        /// 以邻接矩阵的形式存图
        /// </summary>
        private T[][] graphMapMatrix;

        /// <summary>
        /// 以邻接链表的形式存图
        /// </summary>
        private List<T> graphMapLinkedList;

        public T[][] GraphMapMatrix { get => graphMapMatrix; set => graphMapMatrix = value; }
        public List<T> GraphMapLinkedList { get => graphMapLinkedList; set => graphMapLinkedList = value; }
        public int VertexCount { get => vertexCount; set => vertexCount = value; }
        public int EdgeCount { get => edgeCount; set => edgeCount = value; }

        /// <summary>
        /// 打印邻接矩阵
        /// </summary>
        public void PrintMartix() {
            for (int i=0;i<vertexCount;i++) {
                for (int j=0;j<vertexCount;j++) {
                    Console.Write(GraphMapMatrix[i][j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
