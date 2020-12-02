import React from 'react'
import { Grid, Segment,Image, Container } from 'semantic-ui-react'
import GarageList from './GarageList'

const GarageDisplay = () => {
    return (
      <Container>
        <Grid stackable columns={1}>
        <Grid.Column>
         
         
            <GarageList/>
         
         
        </Grid.Column>
        {/* <Grid.Column>
          <Segment>
            <Image src='/images/wireframe/paragraph.png' />
          </Segment>
        </Grid.Column> */}
      </Grid>
      </Container>
    )
}
export default GarageDisplay;