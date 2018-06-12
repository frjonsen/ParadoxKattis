use std;

#[derive(Clone)]
pub struct PointAttributes {
    pub came_from: i32,
    pub cost_sum: i32

}

impl Default for PointAttributes {
    fn default() -> PointAttributes {
        PointAttributes {
            came_from: -1,
            cost_sum: std::i32::MAX
        }
    }
}