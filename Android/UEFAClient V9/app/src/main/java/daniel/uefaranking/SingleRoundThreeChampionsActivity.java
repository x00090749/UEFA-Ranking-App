package daniel.uefaranking;

import android.app.ListActivity;import android.content.Intent;import android.os.Bundle;import android.widget.TextView;


/**
 * Created by Daniel on 21/04/2015.
 */
public class SingleRoundThreeChampionsActivity extends ListActivity
{
    // JSON node keys
    private static final String TAG_TEAMNAME = "TeamName";
    private static final String TAG_COUNTRYCODE = "CountryCode";
    private static final String TAG_RANKING = "Ranking";
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_single_round_one);

        // getting intent data
        Intent in = getIntent();

        // Get JSON values from previous intent
        String TeamName = in.getStringExtra(TAG_TEAMNAME);
        String CountryCode = in.getStringExtra(TAG_COUNTRYCODE);
        String Ranking = in.getStringExtra(TAG_RANKING);

        // Displaying all values on the screen
        TextView lblTeamName = (TextView) findViewById(R.id.TeamName_label);
        TextView lblCountryCode = (TextView) findViewById(R.id.CountryCode_label);
        TextView lblRanking = (TextView) findViewById(R.id.Ranking_label);

        lblTeamName.setText(TeamName);
        lblCountryCode.setText(CountryCode);
        lblRanking.setText(Ranking);
    }

}