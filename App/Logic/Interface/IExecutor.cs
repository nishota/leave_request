using LeaveRequest.App.Models;

namespace LeaveRequest.App.Logic.Interface;

/// <summary>
/// 実行インタフェース
/// CoRを練習のために使ってみたので、特にメリットはない
/// </summary>
public interface IExecutor
{
    void SetNext(IExecutor executor);
    void Execute(Options options);
}