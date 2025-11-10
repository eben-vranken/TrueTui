namespace TrueTui;

public record BorderChars(char Horizontal, char Vertical, char TopLeft, char TopRight, char BottomLeft, char BottomRight)
{    
    public static BorderChars Single = new('─', '│', '┌', '┐', '└', '┘');
    public static BorderChars Double = new('═', '║', '╔', '╗', '╚', '╝');
    public static BorderChars Rounded = new('─', '│', '╭', '╮', '╰', '╯');
    public static BorderChars Ascii = new('-', '|', '+', '+', '+', '+');
}