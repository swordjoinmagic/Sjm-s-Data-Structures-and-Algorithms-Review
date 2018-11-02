using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFindSet{

    /// <summary>
    /// 并查集,使用树来表示,有两种启发函数,这里用最简单那种,即father[i]到达根部时,指向自己
    /// 最典型的两个操作是:
    ///     <para>
    ///         1. 查集
    ///         
    ///     </para>
    ///   
    /// </summary>
    class UnionFindSet {
        // 父亲数组,father[i] = j,表示i的父节点是j
        private int[] father;
        // 高度数组,记录每棵树的高度,rank[x]=h表示x元素所含集合的深度为h
        private int[] rank;

        public UnionFindSet(int count) {
            father = new int[count + 1];
            rank = new int[count + 1];
            for (int i = 0; i <= count; i++) {
                father[i] = i;
                rank[i] = 1;
            }
        }

        /// <summary>
        /// 查集操作,查找x所在集合
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Find(int x) {
            if (father[x] != x)       // 如果目前没有到树的根节点,继续往上查
                return Find(father[x]);
            return x;
        }

        /// <summary>
        /// 并集操作,原理是,找到点x和点y的父集合,
        /// 根据某种启发函数,将他们两个集合合并,
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public void Union(int x, int y) {
            // 找到x的所属集合
            int fx = Find(x);
            // 找到y的所属集合
            int fy = Find(y);
            if (fx == fy)
                // 如果两者所属集合相同,那么不需要进行后续操作了
                return;

            /* 
             * 合并两个集合,应用启发函数,
             * 使用树的高度来进行合并,将
             * 高度小的合并到高度大的树上
            */
            if (rank[fx] > rank[fy]) {
                father[fy] = fx;
            } else {
                if (rank[fx] == rank[fy]) {
                    rank[fy]++;
                }
                father[fx] = fy;
            }
        }
    }
}
