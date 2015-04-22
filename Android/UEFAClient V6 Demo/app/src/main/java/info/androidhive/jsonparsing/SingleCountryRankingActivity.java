package info.androidhive.jsonparsing;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.widget.TextView;

/**
 * Created by Daniel on 22/04/2015.
 */
public class SingleCountryRankingActivity extends Activity {

    // JSON node keys
    private static final String TAG_ID = "Id";
    private static final String TAG_COUNTRYNAME = "CountryName";
    private static final String TAG_RANKING = "Ranking";
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_single_country_ranking);

        // getting intent data
        Intent in = getIntent();

        // Get JSON values from previous intent
        String Id = in.getStringExtra(TAG_ID);
        String CountryName = in.getStringExtra(TAG_COUNTRYNAME);
        String Ranking = in.getStringExtra(TAG_RANKING);

        // Displaying all values on the screen
        TextView lblId = (TextView) findViewById(R.id.Id_label);
        TextView lblCountryName = (TextView) findViewById(R.id.CountryName_label);
        TextView lblRanking = (TextView) findViewById(R.id.Ranking_label);

        lblId.setText(Id);
        lblCountryName.setText(CountryName);
        lblRanking.setText(Ranking);
    }
}
