using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
    public enum NodeType
    {
        // ----- Lexer ----- \\
        // identifiers
        IdentifierNode,
        // keywords
        // -- importing
        ImportKeywordNode,
        AsKeywordNode,
        // -- functions
        ClassKeywordNode,
        GuideKeywordNode,
        SwitchKeywordNode,
        FunctionKeywordNode,
        EntryKeywordNode,
        BreakKeywordNode,
        ContinueKeywordNode,
        ReturnKeywordNode,
        // -- scope
        GlobalKeywordNode,
        LocalKeywordNode,
        // -- privacy
        PublicKeywordNode,
        FriendlyKeywordNode,
        PrivateKeywordNode,
        // -- statements
        IfKeywordNode,
        ElseKeywordNode,
		GateKeywordNode,
        FlowKeywordNode,
        // -- loops
        DoKeywordNode,
        ForKeywordNode,
        WhileKeywordNode,
        // -- data structures
        LogicKeywordNode,
        NumKeywordNode,
        TextKeywordNode,
        // operators
        AdditionToken,
        SubtractionToken,
        MultiplicationToken,
        DivisionToken,
		// equating
        EqualsToken,
        NotToken,
        LessThanToken,
        GreaterThanToken,
        // punctuation
        PeriodToken,
        CommaToken,
		ColonToken,
        SemiColonToken,
        QuestionToken,
        ExclamationToken,
        // -- encasings
        OpenParenthesisToken,
        CloseParenthesisToken,
        OpenBraceToken,
        CloseBraceToken,
        OpenBracketToken,
        CloseBracketToken,
        // values
        LogicNode,
        NumNode,
        TextNode,
        // ----- End Lexer ----- \\\



        // ----- Parser ----- \\\
        // Neccessities & Generics
        RootNode,
        TopLevelNode,
        FileScopeStatementNode,
        CodeBodyNode,
        IdentifierListNode,
        EndlessGenericStatementNode,
        GenericStatementNode,
        ConditionNode,
        IfNode,
        GateFlowNode,
        // Compilers & Comments
        CompilerDeclarationNode,
        ImportBlockNode,
        ImportDeclarationNode,
        // Calls
        FunctionCallNode,
        ReturnStatementNode,
        ParamatersNode,
        ParamatersListNode,
        ArgumentsNode,
        ArgumentsListNode,
        // Declarations
        DataStructureDeclarationListNode,
        FunctionDeclarationListNode,
        PrivacyDeclarationNode,
        ScopeDeclarationNode,
        ClassDeclarationNode,
        ClassInternalsNode,
        ClassRepeatableNode,
        SwitchDeclarationNode,
        GuideDeclarationNode,
        FunctionDeclarationNode,
        GuideFunctionDeclarationNode,
        EntryPointDeclarationNode,
        VariableKeywordNode,
        VariableValueNode,
        VariableDeclarationNode,
        ArrayVariableDeclarationNode,
        // Manipulations
        VariableManipulationNode,
        ManipulatingEqualsNode,
        // Statements
        ConditionalStatementNode,
        IfStatementNode,
        ElseIfStatementNode,
        ElseStatementNode,
        GateStatementNode,
        // Loops
        ConditionalLoopNode,
        DoLoopNode,
        ForLoopNode,
        WhileLoopNode
    }
}
