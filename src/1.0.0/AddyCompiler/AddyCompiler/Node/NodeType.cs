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
        FileScopeStatementNode,
        CodeBodyNode,
        IdentifierListNode,
        EndlessGenericStatementNode,
        GenericStatementNode,
        ConditionStatement,
        // Compilers & Comments
        CompilerDeclarationNode,
        ImportDeclarationNode,
        // Calls
        FunctionCallNode,
        ReturnStatementNode,
        ParamatersNode,
        ParamatersListNode,
        ArgumentsNode,
        ArgumentsListNode,
        // Declarations
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
