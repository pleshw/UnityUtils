using System.Collections.Generic;

namespace UnityUtils.Models.Scenes
{
  public abstract class ChatNode
  {
    public string content;
    public bool lastNode => children.Count > 0;

    public Dialog dialog;

    protected ChatNode parent;
    protected List<ChatNode> children;

    public ChatNode(string _content, Dialog _dialog)
      => (content, parent, dialog) = (_content, null, _dialog);

    public ChatNode(string _content, ChatNode _parent, Dialog _dialog)
      => (content, parent, dialog) = (_content, _parent, _dialog);

    public ChatNode(string _content, ChatNode _parent)
      : this(_content, _parent, _parent.dialog)
    { }

    public virtual void Next()
      => Next(0);

    public virtual void Next(int index)
    {
      if (lastNode)
      {
        EndDialog();
      }
      else
      {
        dialog.SetCurrent(children[index]);
      }
    }

    public abstract void EndDialog();
  }
}