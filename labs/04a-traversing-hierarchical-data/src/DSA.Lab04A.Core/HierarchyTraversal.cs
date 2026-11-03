using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DSA.Lab04A
{
    /// <summary>
    /// Recursive algorithms over a rooted hierarchy.
    ///
    /// The key idea is structural recursion:
    /// solve the current node, then apply the same operation to each child subtree.
    /// </summary>
    public static class HierarchyTraversal
    {
        public static int CountNodes<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            
            int count = 1;
            foreach (HierarchyNode<T> child in root.Children)
            {
                count += CountNodes(child);
            }
            return count;
            
        }

        public static bool Contains<T>(HierarchyNode<T> root, T target)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            
            bool contains = false;
            
            foreach (HierarchyNode<T> child in root.Children)
            {
                if (child.Value.Equals(target))
                {
                    contains = true;
                    break;
                }
                contains = Contains<T>(child, target);
            }
            
            return contains;
        }

        public static IReadOnlyList<T> DepthFirstPreOrder<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            List<T> result = new List<T>();
            result.Add(root.Value);
            foreach (var child in root.Children)
            {
                if (child.IsLeaf == true)
                {
                    result.Add(child.Value);
                }
                else
                {
                    IReadOnlyList<T> childresult = DepthFirstPreOrder<T>(child);
                    result.AddRange(childresult);
                }
                
            }
            return result;
        }

        public static int MaxDepth<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            int maxdepth = 0;
            foreach (var child in root.Children)
            {
                int depth = 1 + MaxDepth<T>(child);
                if (depth > maxdepth)
                {
                    maxdepth = depth;
                }
            }

            return maxdepth;
        }
    }
}
