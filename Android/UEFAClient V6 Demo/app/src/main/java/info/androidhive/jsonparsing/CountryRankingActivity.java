package info.androidhive.jsonparsing;

import android.app.ListActivity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;

/**
 * Created by Daniel on 22/04/2015.
 */
public class CountryRankingActivity extends ListActivity
{
    private ProgressDialog pDialog;

    //URL to get Teams
    private static String url = "http://uefaservicev9.azurewebsites.net/api/countryrankingsapi/";

    //JSON Node names
    private static final String TAG_ID = "Id";
    private static final String TAG_COUNTRYNAME = "CountryName";
    private static final String TAG_RANKING = "Ranking";

    // Country rankings JSONArray
    JSONArray countryRankings = null;

    //Hashmap for ListView
    ArrayList<HashMap<String, String>> countryRankingList;

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        countryRankingList = new ArrayList<HashMap<String, String>>();

        ListView lv = getListView();

        // Listview on item click listener
        lv.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int positions, long id) {
                // getting values from selected ListItem
                String Id = ((TextView) view.findViewById(R.id.Id))
                        .getText().toString();
                String CountryName = ((TextView) view.findViewById(R.id.CountryName))
                        .getText().toString();
                String Ranking = ((TextView) view.findViewById(R.id.Ranking))
                        .getText().toString();

                // Starting single contact activity
                Intent in = new Intent(getApplicationContext(),
                        SingleCountryRankingActivity.class);
                in.putExtra(TAG_ID, Id); //name
                in.putExtra(TAG_COUNTRYNAME, CountryName); //cost
                in.putExtra(TAG_RANKING, Ranking); //description
                startActivity(in);

            }
        });

        // Calling async task to get json
        new GetTeamRankings().execute();
    }

    /**
     * Async task class to get json by making HTTP call
     * */
    private class GetTeamRankings extends AsyncTask<Void, Void, Void>
    {

        @Override
        protected void onPreExecute()
        {
            super.onPreExecute();
            // Showing progress dialog
            pDialog = new ProgressDialog(CountryRankingActivity.this);
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
                    JSONArray countryRankings = new JSONArray(jsonStr);
                    //JSONArray countries = new JSONArray(jsonStr);
                    //countries = jsonStr("Country"); //TAG_COUNTRIES

                    // looping through All Countries
                    for (int i = 0; i < countryRankings.length(); i++) {
                        JSONObject c = countryRankings.getJSONObject(i);

                        String Id ="Position: " + c.getString(TAG_ID); //Id
                        String CountryName ="Country: " + c.getString(TAG_COUNTRYNAME); //"CountryName"
                        //String CountryCode = c.getString(TAG_COUNTRYCODE); //"CountryCode
                        String Ranking = "Coefficient " + c.getString(TAG_RANKING); //"Ranking"


                        // tmp hashmap for single contact
                        HashMap<String, String> countryRanking = new HashMap<String, String>();

                        // adding each child node to HashMap key => value
                        countryRanking.put(TAG_ID, Id);
                        countryRanking.put(TAG_COUNTRYNAME, CountryName);
                        //countryRanking.put(TAG_COUNTRYCODE, CountryCode);
                        countryRanking.put(TAG_RANKING, Ranking);

                        // adding contact to contact list
                        countryRankingList.add(countryRanking); //was country
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
            ListAdapter adapter = new SimpleAdapter
                    (
                            CountryRankingActivity.this,
                            countryRankingList,
                            R.layout.list_country_ranking,
                            new String[] { TAG_ID, TAG_COUNTRYNAME, TAG_RANKING },
                            new int[] { R.id.Id,R.id.CountryName, R.id.Ranking }
                    );

            setListAdapter(adapter);
        }

    }
}