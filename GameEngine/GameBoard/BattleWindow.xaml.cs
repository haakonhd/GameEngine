using GameEngine.Events;
using GameEngine.GameObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GameEngine.GameBoard
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class BattleWindow : Page
	{
		public BattleWindow()
		{
			this.InitializeComponent();

			startMatch();
		}

		private void startMatch()
		{
			HeroSprite.Source = Battle.Instance.Hero?.BattleSprite.SpriteImage.Source;
			EnemySprite.Source = Battle.Instance.Enemy?.BattleSprite.SpriteImage.Source;
		}

		private void attackClicked(object sender, RoutedEventArgs e)
		{
			AttackList.Visibility = Visibility.Visible;
		}

		private void inventoryClicked(object sender, RoutedEventArgs e)
		{
			ItemList.Visibility = Visibility.Visible;
		}

		private void runClicked(object sender, RoutedEventArgs e)
		{
			//TODO: randomly disallow run based on hero vs enemy level
			Frame.Navigate(typeof(GameWindow), Game.Instance);
		}

		private void attackList_ItemClick(object sender, ItemClickEventArgs e)
		{
			IBattleAttack clickedItem = (IBattleAttack)e.ClickedItem;
			attackFighter(clickedItem, Battle.Instance.Enemy);
			AttackList.Visibility = Visibility.Collapsed;
		}

		private void attackFighter(IBattleAttack attack, IFighter fighter)
		{
			fighter.HealthPoints -= attack.AttackDamage;
			foreach (Action effect in attack.AttackEffects)
				effect.Invoke();
		}

		private void itemList_ItemClick(object sender, ItemClickEventArgs e)
		{
			IInventoryItem clickedItem = (IInventoryItem)e.ClickedItem;
			foreach (Action effect in clickedItem.ItemEffects)
				effect.Invoke();
			ItemList.Visibility = Visibility.Collapsed;
		}
	}
}
