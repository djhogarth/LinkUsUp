import React, { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';
import { AppBar, Box, Icon, IconButton, List, ListItem, Toolbar, Typography} from '@mui/material';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { solid } from '@fortawesome/fontawesome-svg-core/import.macro'
import { spacing } from '@mui/system';

function App() {
  const [activities, setActivities] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5000/api/activities').then(response => {
      console.log(response);
      setActivities(response.data);
    })
  }, [])

  return (
    <div>
      <Box sx={{ flexGrow: 1 }}>
        <AppBar position='static' color='default'>
          <Toolbar>
            <IconButton color="inherit" sx={{mr: 1}}>
              <FontAwesomeIcon icon={solid('users')} size='2x' />
            </IconButton>            
            <Typography variant="h3">LinkUsUp</Typography>
          </Toolbar>
        </AppBar>
      </Box>

      <List>
        {activities.map((activity: any) => (
          <ListItem key={activity.id}>
            {activity.title}
          </ListItem>
        ))}
      </List>      

    </div>
  );
}

export default App;
