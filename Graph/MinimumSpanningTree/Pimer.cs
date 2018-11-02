using System;
using System.Collections.Generic;
using System.Text;

namespace Graph{

    /// <summary>
    /// 使用Primer算法求最短路
    /// <para>
    ///     算法思路:
    ///         将所有边按照从小到大的顺序进行排列.
    ///         对于一个边,判断他是否要加入最小生成树中,如果这个边的对应的两个点
    ///         之前都没有见过,则加入,如果这条边的两个点中任意一个之前出现过,则不加入
    ///         最后,当遍历完所有边后,得到的就是最小生成树
    /// </para>
    /// <para>
    ///     测试数据(第一行是点n和边m,后面m行是,点x和点y之间的距离):
    ///         6 10
    ///         0 1 45
    ///         0 3 10
    ///         0 2 28
    ///         1 2 12
    ///         1 4 21
    ///         2 3 17
    ///         2 4 26
    ///         3 4 15
    ///         3 5 13
    ///         4 5 11
    /// </para>
    /// </summary>
    public class Pimer{

        public struct Edge {
            public int point1;
            public int point2;
            public int edge;
        }

        private int vertexCount;
        private int edgeCount;

        private List<Edge> list = new List<Edge>();

        public void Slove() {
            string[] line = Console.ReadLine().Split(" ");
            vertexCount = int.Parse(line[0]);
            edgeCount = int.Parse(line[1]);

            // 读取所有边,并加入列表中
            for (int i = 0; i < edgeCount; i++) {
                line = Console.ReadLine().Split(" ");
                int point1 = int.Parse(line[0]);
                int point2 = int.Parse(line[1]);
                int edge = int.Parse(line[2]);
                list.Add(new Edge() { point1 = point1, point2 = point2, edge = edge });
            }

            // 对边进行排序(根据边的大小)
            list.Sort(
                (Edge e1, Edge e2) => {
                    if (e1.edge > e2.edge) {
                        return 1;
                    } else if (e1.edge < e2.edge) {
                        return -1;
                    } else {
                        return 0;
                    }
                }
            );

            foreach (Edge edge in list) {
                Console.WriteLine(edge.edge);
            }

            int result = 0;

            UnionFindSet.UnionFindSet unionFindSet = new UnionFindSet.UnionFindSet(vertexCount);
            for (int i=0;i<edgeCount;i++) {
                Edge edge = list[i];
                if (unionFindSet.Find(edge.point1)!=unionFindSet.Find(edge.point2)) {
                    unionFindSet.Union(edge.point1,edge.point2);
                    result += edge.edge;
                }
            }

            Console.WriteLine("最小生成树权值是:"+result);
        }

    }
}
