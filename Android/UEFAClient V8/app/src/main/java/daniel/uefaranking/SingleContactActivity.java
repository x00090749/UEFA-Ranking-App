package daniel.uefaranking;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.widget.TextView;
import daniel.uefaranking.R;

public class SingleContactActivity  extends Activity {
	
	// JSON node keys
	private static final String TAG_COUNTRYNAME = "CountryName";
	private static final String TAG_COUNTRYCODE = "CountryCode";
	private static final String TAG_POSITION = "Position";
	@Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_single_contact);
        
        // getting intent data
        Intent in = getIntent();
        
        // Get JSON values from previous intent
        String CountryName = in.getStringExtra(TAG_COUNTRYNAME);
        String CountryCode = in.getStringExtra(TAG_COUNTRYCODE);
        String Position = in.getStringExtra(TAG_POSITION);
        
        // Displaying all values on the screen
        TextView lblCountryName = (TextView) findViewById(R.id.CountryName_label);
        TextView lblCountryCode = (TextView) findViewById(R.id.CountryCode_label);
        TextView lblPosition = (TextView) findViewById(R.id.Position_label);
        
        lblCountryName.setText(CountryName);
        lblCountryCode.setText(CountryCode);
        lblPosition.setText(Position);
    }
}
