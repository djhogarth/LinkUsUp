import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { AppBar, Box, Icon, IconButton, List, ListItem, Toolbar, Typography} from '@mui/material';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { solid } from '@fortawesome/fontawesome-svg-core/import.macro'
import { spacing } from '@mui/system';
import { Activity } from '../interfaces/activity';
import NavBar from './NavBar';

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    axios.get<Activity[]>('http://localhost:5000/api/activities').then(response => {
      setActivities(response.data);
    })
  }, [])

  return (
    <div>
      <NavBar/>

      <List>
        {activities.map(activity => (
          <ListItem key={activity.id}>
            {activity.title}
          </ListItem>
        ))}
      </List>      

    </div>
  );
}

export default App;
