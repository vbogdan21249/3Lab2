using goods;
using System.Collections;
namespace binary_tree
{

    public class BinaryTreeNode<T> : IComparable<BinaryTreeNode<T>> where T : IComparable<T>
    {

        public T Data { get; set; }
        public BinaryTreeNode<T>? Right { get; set; }
        public BinaryTreeNode<T>? Left { get; set; }

        public BinaryTreeNode(T data)
        {
            Data = data;
        }
        public int CompareTo(BinaryTreeNode<T>? other)
        {       
            if (other == null)
            {
                return 1;
            }
            return Data.CompareTo(other.Data);
        }
    }


    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T>? Root { get; private set; }
        public BinaryTree()
        {
            Root = null;
        }
        public void Insert(T data)
        {
            Root = InsertRec(Root, data);
        }
        private BinaryTreeNode<T> InsertRec(BinaryTreeNode<T> root, T data)
        {
            if (root == null)
            {
                return new BinaryTreeNode<T>(data);
            }
            int comparisonResult = Comparer<T>.Default.Compare(data, root.Data);
            if (comparisonResult < 0)
            {
                root.Left = InsertRec(root.Left, data);
            }
            else if (comparisonResult > 0)
            {
                root.Right = InsertRec(root.Right, data);
            }
            return root;

        }
        public IEnumerator<T> GetEnumerator()
        {
            return new GoodsEnumerator<T>(Root);
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
    public class GoodsEnumerator<T> : IEnumerator<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T>? _root;
        private BinaryTreeNode<T>? _current;
        private bool movedNext = false;
        public GoodsEnumerator(BinaryTreeNode<T>? node)
        {
            _root = node;
        }
        public T Current => _current.Data;
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public bool MoveNext()
        {
            if (_root == null)
            {
                return false;
            }

            if (!movedNext)
            {
                _current = GetLeftmostNode(_root);
                movedNext = true;
                return _current != null;
            }

            if (_current?.Right != null)
            {
                _current = GetLeftmostNode(_current.Right);
                return _current != null;
            }

            while (_current != null)
            {
                BinaryTreeNode<T>? parent = FindParent(_root, _current);

                if (parent == null)
                {
                    _current = null;
                    return false;
                }

                if (parent.Left == _current)
                {
                    _current = parent;
                    return true;
                }

                _current = parent;
            }

            return false;
        }

        public void Reset()
        {
            _current = null;
            movedNext = false;
        }

        private BinaryTreeNode<T> GetLeftmostNode(BinaryTreeNode<T> node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }

        private BinaryTreeNode<T>? FindParent(BinaryTreeNode<T>? root, BinaryTreeNode<T> node)
        {
            if (root == null || node == root)
            {
                return null;
            }

            if (root.Left == node || root.Right == node)
            {
                return root;
            }

            if (node.Data.CompareTo(root.Data) < 0)
            {
                return FindParent(root?.Left, node);
            }
            else
            {
                return FindParent(root?.Right, node);
            }
        }

        public void Dispose()
        {
        }
    }
}