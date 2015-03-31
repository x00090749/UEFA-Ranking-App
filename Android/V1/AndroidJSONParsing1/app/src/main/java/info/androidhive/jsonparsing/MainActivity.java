package info.androidhive.jsonparsing;

import info.androidhive.jsonparsing.R;
import java.util.ArrayList;
import java.util.HashMap;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.app.ListActivity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.TextView;

public class MainActivity extends ListActivity {

	private ProgressDialog pDialog;

	// URL to get contacts JSON
	//private static String url = "http://api.androidhive.info/contacts/";
    private static String url = "http://uefaservicev3.azurewebsites.net/api/countries/";

	// JSON Node names

    private static final String TAG_COUNTRIES = "Country"; //countries
    private static final String TAG_ID = "Id";
    private static final String TAG_COUNTRYNAME = "CountryName";
    private static final String TAG_COUNTRYCODE =  "CountryCode";
    private static final String TAG_POSITION = "Position";


	// contacts JSONArray
	JSONArray countries = null;

	// Hashmap for ListView
	ArrayList<HashMap<String, String>> countriesList;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

        countriesList = new ArrayList<HashMap<String, String>>();

		ListView lv = getListView();

		// Listview on item click listener
		lv.setOnItemClickListener(new OnItemClickListener() {

			@Override
			public void onItemClick(AdapterView<?> parent, View view,
					int positions, long id) {
				// getting values from selected ListItem
				String CountryName = ((TextView) view.findViewById(R.id.CountryName))
						.getText().toString();
				String CountryCode = ((TextView) view.findViewById(R.id.CountryCode))
						.getText().toString();
				String Position = ((TextView) view.findViewById(R.id.Position))
						.getText().toString();

				// Starting single contact activity
				Intent in = new Intent(getApplicationContext(),
						SingleContactActivity.class);
				in.putExtra(TAG_COUNTRYNAME, CountryName); //name
				in.putExtra(TAG_COUNTRYCODE, CountryCode); //cost
				in.putExtra(TAG_POSITION, Position); //description
				startActivity(in);

			}
		});

		// Calling async task to get json
		new GetCountries().execute();
	}

	/**
	 * Async task class to get json by making HTTP call
	 * */
	private class GetCountries extends AsyncTask<Void, Void, Void> {

		@Override
		protected void onPreExecute() {
			super.onPreExecute();
			// Showing progress dialog
			pDialog = new ProgressDialog(MainActivity.this);
			pDialog.setMessage("Please wait...");
			pDialog.setCancelable(false);
			pDialog.show();

		}

		@Override
		protected Void doInBackground(Void... arg0) {
			// Creating service handler class instance
			ServiceHandler sh = new ServiceHandler();

			// Making a request to url and getting response
			String jsonStr = sh.makeServiceCall(url, ServiceHandler.GET);

			Log.d("Response: ", "> " + jsonStr);

			if (jsonStr != null) {
				try {
                    JSONArray countries = new JSONArray(jsonStr);
                    //JSONArray countries = new JSONArray(jsonStr);
					//countries = jsonStr("Country"); //TAG_COUNTRIES

					// looping through All Countries
					for (int i = 0; i < countries.length(); i++) {
						JSONObject c = countries.getJSONObject(i);
						
						String Id = c.getString(TAG_ID); //Id
						String CountryName = c.getString(TAG_COUNTRYNAME); //"CountryName"
						String CountryCode = c.getString(TAG_COUNTRYCODE); //"CountryCode
						String Position = c.getString(TAG_POSITION); //"Position"


						// tmp hashmap for single contact
						HashMap<String, String> country = new HashMap<String, String>();

						// adding each child node to HashMap key => value
						country.put(TAG_ID, Id);
                        country.put(TAG_COUNTRYNAME, CountryName);
                        country.put(TAG_COUNTRYCODE, CountryCode);
                        country.put(TAG_POSITION, Position);

						// adding contact to contact list
						countriesList.add(country);
					}
				} catch (JSONException e) {
					e.printStackTrace();
				}
			} else {
				Log.e("ServiceHandler", "Couldn't get any data from the url");
			}

			return null;
		}

		@Override
		protected void onPostExecute(Void result) {
			super.onPostExecute(result);
			// Dismiss the progress dialog
			if (pDialog.isShowing())
				pDialog.dismiss();
			/**
			 * Updating parsed JSON data into ListView
			 * */
			ListAdapter adapter = new SimpleAdapter(
					MainActivity.this, countriesList,
					R.layout.list_item, new String[] { TAG_COUNTRYNAME, TAG_COUNTRYCODE,
							TAG_POSITION }, new int[] { R.id.CountryName,
							R.id.CountryCode, R.id.Position });

			setListAdapter(adapter);
		}

	}

}