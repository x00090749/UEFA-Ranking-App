package daniel.uefaranking;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.widget.Button;
import android.view.View.OnClickListener;
import android.content.Intent;

public class MainMenuActivity extends Activity
{
    Button button;

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main_menu);
    }

    //Main Menu Qualifying Rounds Intent
    public void MainMenuQualifyingActivity(View view)
    {
        startActivity(new Intent(MainMenuActivity.this, MainMenuQualifyingActivity.class));
    }

    //Team Ranking Intent
    public void TeamRankingActivity(View view)
    {
        startActivity(new Intent(this, TeamRankingActivity.class));
    }

    //Country Ranking Intent
    public void CountryRankingActivity(View view) {
        startActivity(new Intent(MainMenuActivity.this, CountryRankingActivity.class));
    }

    //Help Section Intent
    public void HelpActivity(View view) {
        startActivity(new Intent(MainMenuActivity.this, HelpActivity.class));
    }

    //About Section Intent
    public void AboutActivity(View view) {
        startActivity(new Intent(MainMenuActivity.this, AboutActivity.class));
    }

}


