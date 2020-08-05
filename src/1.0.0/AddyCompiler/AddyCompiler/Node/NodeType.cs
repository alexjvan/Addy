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
        FunctionKeywordNode,
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
        StatementNode,
        // Compilers & Comments
        CompilerDeclarationNode,
        ImportDeclaration,
        // Calls
        FunctionCallNode,
        // Declarations
        ClassDeclarationNode,
        SwitchDeclarationNode,
        GuideDeclarationNode,
        FunctionDeclarationNode,
        EntryPointDeclarationNode,
        VariableDeclarationNode,
        // Statements
        IfStatementNode,
        ElseStatementNode,
        // Loops
        DoLoopNode,
        ForLoopNode,
        WhileLoopNode
    }
}
