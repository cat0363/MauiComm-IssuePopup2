using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace MauiComm_IssuePopup2;

public partial class MainPage : ContentPage
{
    private Indicator pIndicator = null;
	private int pItemNum = 0;

	private ObservableCollection<TestItem> TestItems = new ObservableCollection<TestItem>();
    
    public MainPage()
	{
		InitializeComponent();

		for(int i = 0; i < 15; i++)
		{
			TestItems.Add(new TestItem() { ItemName = "Item Name " + pItemNum });
			pItemNum++;
		}
		BindableLayout.SetItemsSource(slTestItems, TestItems);

	}

	private void GetTestItem()
	{
        for (int i = 0; i < 15; i++)
        {
            TestItems.Add(new TestItem() { ItemName = "Item Name " + pItemNum });
            pItemNum++;
        }
    }

    private void svTestItems_Scrolled(object sender, ScrolledEventArgs e)
    {
        if (Math.Abs((svTestItems.ContentSize.Height - svTestItems.Height) - svTestItems.ScrollY) <= 100)
		{
            svTestItems.Scrolled -= new EventHandler<ScrolledEventArgs>(svTestItems_Scrolled);

            ShowIndicator();

            GetTestItem();

            CloseIndicator();

            svTestItems.Scrolled += new EventHandler<ScrolledEventArgs>(svTestItems_Scrolled);
        }
    }

    private void ShowIndicator()
    {
        if (pIndicator == null)
        {
            pIndicator = new Indicator();
            this.ShowPopup(pIndicator);
        }
    }

    private void CloseIndicator()
    {
        if (pIndicator != null)
        {
            pIndicator.Close();
            pIndicator = null;
        }
    }
}

public class TestItem
{
	public string ItemName { get; set; }
}