using System;
using System.Collections.Generic;

namespace apcy.Tools.Entidad
{

    public class TreeObject
    {
        public LinkedList<TreeObjectNode> Roots = null;

        public TreeObject()
        {
            Roots = new LinkedList<TreeObjectNode>();
        }

        public void InsertRoot(TreeObjectNode child)
        {
            Roots.AddLast(child);
        }

    }



    public class TreeObjectListBuilder
    {

        public bool IdentLevel { get; set; }

        //public List<object[]> GetInformativeList<T>(TreeObject tree, List<TreeObjectListBuilderCommand> commands)
        //{
        //    List<object[]> listFormated = new List<object[]>();

        //    Type itemsType = typeof(T);
        //    object keyVal = null;
        //    object parentVal = null; //usually types are primitives

        //    foreach (TreeObjectNode obj in tree.Roots)
        //    {
        //        if (obj.Data != null)
        //        {
        //            foreach (TreeObjectListBuilderCommand comm in commands)
        //            { 
        //                foreach (System.Reflection.PropertyInfo prop in itemsType.GetProperties())
        //                {
        //                    if (nameKeyProp.Equals(prop.Name))
        //                        keyVal = prop.GetValue(obj.Data, null);
        //                    if (nameParentProp.Equals(prop.Name))
        //                        parentVal = prop.GetValue(obj.Data, null);
        //                } 
        //            }


        //            GetInformativeListFromChildren<T>(listFormated, obj, nameKeyProp, nameParentProp);
        //        }
        //    }
        //    return listFormated;
        //}

        //private List<object[]> GetInformativeListFromChildren<T>(List<object[]> listFormated, TreeObjectNode node, string nameKeyProp, string nameParentProp)
        //{
        //    if (string.IsNullOrEmpty(nameKeyProp)) throw new HelperException("Key property name needed.");
        //    if (string.IsNullOrEmpty(nameParentProp)) throw new HelperException("Parent property name needed.");

        //    Type itemsType = typeof(T);
        //    object keyVal = null;
        //    object parentVal = null; //usually types are primitives

        //    foreach (TreeObjectNode obj in node.Children)
        //    {
        //        if (obj.Data != null)
        //        {
        //            foreach (System.Reflection.PropertyInfo prop in itemsType.GetProperties())
        //            {
        //                if (nameKeyProp.Equals(prop.Name))
        //                    keyVal = prop.GetValue(obj, null);
        //                if (nameParentProp.Equals(prop.Name))
        //                    parentVal = prop.GetValue(obj, null);
        //            }
        //            GetInformativeListFromChildren<T>(listFormated, obj, nameKeyProp, nameParentProp);
        //        }

        //    }
        //    return listFormated;
        //}

        public static TreeObject ConvertListToTreeObject<T>(List<T> data, string nameKeyProp, string nameParentProp, object rootValue)
        {

            if (rootValue==null) throw new HelperException("Root value needed.");
            if (string.IsNullOrEmpty(nameKeyProp)) throw new HelperException("Key property name needed.");
            if (string.IsNullOrEmpty(nameParentProp)) throw new HelperException("Parent property name needed.");

            TreeObject tree = new TreeObject();
            Type itemsType = typeof(T); 
            TreeObjectNode node = null;
            object keyVal = null;
            object parentVal = null; //usually types are primitives

            foreach (T obj in data)
            { 
                foreach (System.Reflection.PropertyInfo prop in itemsType.GetProperties())
                {
                    if (nameKeyProp.Equals(prop.Name))
                        keyVal = prop.GetValue(obj, null);
                    if (nameParentProp.Equals(prop.Name))
                        parentVal = prop.GetValue(obj, null);
                }
                
                if (parentVal.ToString() == rootValue.ToString())
                {
                    node = new TreeObjectNode
                    {
                        Data = obj,
                        IdParent = parentVal,
                        Id = keyVal
                    }; 
                    tree.InsertRoot(node);
                    BuildChildren<T>(data, node, nameKeyProp, nameParentProp);
                } 
            } 
            return tree;
        }

        private static void BuildChildren<T>(List<T> data, TreeObjectNode nodeParent, string nameKeyProp, string nameParentProp)
        { 
            Type itemsType = typeof(T);
            TreeObjectNode node = null;
            object keyVal = null;
            object parentVal = null; //usually types primitives

            foreach (T obj in data)
            {
                foreach (System.Reflection.PropertyInfo prop in itemsType.GetProperties())
                {
                    if (nameKeyProp.Equals(prop.Name))
                        keyVal = prop.GetValue(obj, null);
                    if (nameParentProp.Equals(prop.Name))
                        parentVal = prop.GetValue(obj, null);
                }

                if (parentVal.ToString() == nodeParent.Id.ToString())
                {
                    node = new TreeObjectNode
                    {
                        Data = obj,
                        IdParent = parentVal,
                        Id = keyVal
                    };
                    nodeParent.InsertChild(node);
                    BuildChildren<T>(data, node, nameKeyProp, nameParentProp);
                }
            }

        }

    }

    public class TreeObjectListBuilderCommand
    {

        public enum TypeTreeObjectParseAction
        {
            Increment = 1,
            Print = 2
        }

        public TypeTreeObjectParseAction Action { get; set; }
        public string NameProperty { get; set; }
    }


    public class TreeObjectNode
    {
        public TreeObjectNode Parent { get; set; }
        public LinkedList<TreeObjectNode> Children = null;
        public object Id { get; set; }
        public object IdParent { get; set; }
        public object Data { get; set; }


        public TreeObjectNode()
        {
            Children = new LinkedList<TreeObjectNode>();
        }

        public void InsertChild(TreeObjectNode child)
        {
            Children.AddLast(child);
        }

    }


}
