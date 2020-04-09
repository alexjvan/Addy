using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
    public abstract class BuildingNode
    {
        private NodeType _type;

        public NodeType Type
        {
            get
            {
                return _type;
            }
        }

        public BuildingNode(NodeType type)
        {
            _type = type;
        }
    }
}
