using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class QuestController : MonoBehaviour
{
    public static QuestController Instance { get; private set; }
    public List<QuestProgress> activateQuests = new();
    private QuestUI questUI;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        questUI = FindAnyObjectByType<QuestUI>();
        InventoryController.Instance.OnInventoryChanged += CheckInventoryforQuests;
    }

    public void AcceptQuest(Quest quest) 
    {
        if (isQuestActive(quest.questID)) return;
        
        activateQuests.Add(new QuestProgress(quest));

        CheckInventoryforQuests();
        questUI.UpdateQuestUI();
    }

    public bool isQuestActive(string questID) => activateQuests.Exists(q => q.QuestID == questID);

    public void CheckInventoryforQuests() 
    {
        Dictionary<int, int> itemCounts = InventoryController.Instance.GetItemCounts();
        foreach(QuestProgress quest in activateQuests) 
        {
            foreach(QuestObjective questObjective in quest.objectives) 
            {
                if (questObjective.type != ObjectiveType.CollectItem) continue;
                if (!int.TryParse(questObjective.objectiveID, out int itemID)) continue;

                int newAmount = itemCounts.TryGetValue(itemID, out int count) ? Mathf.Min(count, questObjective.requiredAmount) : 0;

                if (questObjective.currentAmount != newAmount) 
                {
                    questObjective.currentAmount = newAmount;
                }
            }
        }

        questUI.UpdateQuestUI();
    }

    public void LoadQuestProgress(List<QuestProgress> savedQuests) 
    {
        activateQuests = savedQuests ?? new();

        CheckInventoryforQuests();
        questUI.UpdateQuestUI();
    }
}
